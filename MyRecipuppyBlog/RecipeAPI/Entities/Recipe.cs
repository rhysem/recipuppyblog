using System.Text.Json.Serialization;

namespace RecipeAPI.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        [JsonPropertyName("name")] // TODO - is this even needed if same name?
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; } // is whitespace preserved here + in recipe steps? if not, convert to list and parse into array in js
        public string Directions { get; set; }
        //public Category Category { get; set; }
    }
}
