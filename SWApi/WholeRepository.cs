using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SWApi
{
	public class WholeRepository
	{
		private readonly string connectionString;

		public WholeRepository(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public void AddList(List<Person> persons)
		{
			var sql = "Insert into Persons (Id, Name, Height, Mass, HairColor, SkinColor, EyeColor, BirthYear, Gender, Homeworld, CreatedDate, EditedDate, Url) Values (@Id, @Name, @Height, @Mass, @HairColor, @SkinColor, @EyeColor, @BirthYear, @Gender, @Homeworld, @CreatedDate, @EditedDate, @Url);";
			using (var connection = new SqlConnection(connectionString))
			{
				foreach (var person in persons)
				{
					var rowAffected = connection.Execute(sql, person);
					if (rowAffected != 1)   // так как вставка всего на 1 строку
					{
						throw new Exception("Что-то пошло не так");
					}

					foreach(var film in person.Films)
					{
						var insertFilm = "Insert into Films (PersonId, Film) Values (@PersonId, @Film)";
						connection.Execute(insertFilm, new { PersonId = person.Id, Film = film });
					}

					foreach (var species in person.Species)
					{
						var insertSpecies = "Insert into Species (PersonId, Species) Values (@PersonId, @Species)";
						connection.Execute(insertSpecies, new { PersonId = person.Id, Species = species });
					}

					foreach (var vehicle in person.Vehicles)
					{
						var insertVehicle = "Insert into Vehicles (PersonId, Vehicle) Values (@PersonId, @Vehicle)";
						connection.Execute(insertVehicle, new { PersonId = person.Id, Vehicle = vehicle });
					}

					foreach (var starship in person.Starships)
					{
						var insertStarship = "Insert into Starships (PersonId, Starship) Values (@PersonId, @Starship)";
						connection.Execute(insertStarship, new { PersonId = person.Id, Starship = starship });
					}
				}
			}
		}
	}
}
