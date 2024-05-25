using Microsoft.AspNetCore.Mvc;

using RecipeAPI.Entities;
using RecipeAPI.Repositories;

namespace RecipeAPI.Controllers
{
    [ApiController]
    [Route("api/recipes")] // api/[controller] or api/recipes
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipesController()
        {
            // TODO - dependency injection!!!
            _recipeRepository = new RecipeRepository();
        }

        [HttpGet]
        [Route("")]
        [Route("Recipes")]
        public Task<IEnumerable<Recipe>> GetRecipes()
        {
            return _recipeRepository.GetRecipes();
        }

        // TODO - handle CSRF - in whole app!!!
        [HttpPost]
        public Task<Recipe> CreateRecipe(int id, Recipe recipe)
        {
            recipe.Id = id;
            return _recipeRepository.SaveRecipe(recipe);
        }

        //[HttpPost]
        //public async Task<Recipe> SaveRecipe(int? id, Recipe recipe)
        //{
        //    if (id == null)
        //    {

        //    }

        //    // handle updates later
        //}
    }
}
