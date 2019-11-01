using DbUp;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace SWApi
{
	/*
	 По сети получить информацию о персонажах SW с сайта https://swapi.co/ и вставить их в БД через дополнительную библиотеку для Dapper. 
	 */
	class Program
	{
		private static string connectionString = "Server=BORISHOME\\BORIS;Database=StarWarsApi;Trusted_Connection=True;";

		private static WholeRepository wholeRepository = new WholeRepository(connectionString);

		static void Main(string[] args)
		{
			string json = System.IO.File.ReadAllText(@"persons.json");

			var result = JsonConvert.DeserializeObject<List<Person>>(json);

			DbUp();

			wholeRepository.AddList(result);
		}

		private static void DbUp()
		{
			EnsureDatabase.For.SqlDatabase(connectionString);  // Создание БД

			var upgrader =
					DeployChanges.To                      // Накатывание всех скриптов
							.SqlDatabase(connectionString)
							.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly()) // Получение всех файлов в сборке со словом Script и параметром Embedded
							.LogToConsole()
							.Build();
			upgrader.PerformUpgrade();
		}
	}
}
