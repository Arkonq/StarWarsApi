using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SWApi
{
	public partial class Results
	{
		[JsonProperty("results")]
		public List<Person> Persons { get; set; }
	}

	public partial class Person
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("height")]
		public string Height { get; set; } // У другого вообще не смогли определить рост...
		[JsonProperty("mass")]
		public string Mass { get; set; } // У какого-то чела не известа его масса, и они решили вставить слово unknown, поэтому string
		[JsonProperty("hair_color")]
		public string HairColor { get; set; }
		[JsonProperty("skin_color")]
		public string SkinColor { get; set; }
		[JsonProperty("eye_color")]
		public string EyeColor { get; set; }
		[JsonProperty("birth_year")]
		public string BirthYear { get; set; }
		[JsonProperty("gender")]
		public string Gender { get; set; }
		[JsonProperty("homeworld")]
		public string Homeworld { get; set; }
		[JsonProperty("films")]
		public string[] Films { get; set; }
		[JsonProperty("species")]
		public string[] Species { get; set; }
		[JsonProperty("vehicles")]
		public string[] Vehicles { get; set; }
		[JsonProperty("starships")]
		public string[] Starships { get; set; }
		[JsonProperty("created")]
		public DateTime CreatedDate { get; set; }
		[JsonProperty("edited")]
    public DateTime EditedDate { get; set; }
		[JsonProperty("url")]
    public string Url { get; set; }
	}
}
