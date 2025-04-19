using System.Data.Entity;

using RecipeAPI.Entities;

namespace RecipeAPI.Repositories
{
    public class RecipeContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
    }
}
