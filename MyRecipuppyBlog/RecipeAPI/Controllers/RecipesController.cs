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

        public RecipesController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpGet]
        [Route("")]
        public Task<IEnumerable<Recipe>> GetRecipes()
        {
            return _recipeRepository.GetRecipes();
        }

        // TODO - handle CSRF - in whole app!!!
        [HttpPost]
        [Route("")]
        public async Task<string> CreateRecipe(Recipe recipe)
        {
            try
            {
                return await _recipeRepository.SaveRecipeAsync(recipe);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return "-1";
            }
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
