using System.Text.Json.Serialization;

namespace RecipeAPI.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        [JsonPropertyName("name")] // TODO - is this even needed if same name?
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> RecipeSteps { get; set; }
        public string SingleStepRecipeText { get; set; }
        //public Category Category { get; set; }
    }
}
