namespace RecipeAPI.Entities
{
    public class Recipe
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; } // is whitespace preserved here + in recipe steps? if not, convert to list and parse into array in js
        public string Directions { get; set; }
        //public Category Category { get; set; }
    }
}
