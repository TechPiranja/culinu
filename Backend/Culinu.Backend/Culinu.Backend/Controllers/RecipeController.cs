using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Culinu.Backend.Models;

namespace Culinu.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly CulinuContext _context;

        public RecipeController(CulinuContext context)
        {
            _context = context;
        }

        // GET: api/Recipe
        [HttpGet]
        public ActionResult<IEnumerable<RecipeModel>> GetRecipes()
        {
            if (_context.Recipes == null)
            {
                return NotFound();
            }

            return _context.Recipes
                .Include(x => x.Ingredients)
                .Include(x => x.Descriptions.OrderBy(x => x.Id))
                .ToList();
        }

        // GET: api/Recipe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeModel>> GetRecipeModel(int id)
        {
            if (_context.Recipes == null)
            {
                return NotFound();
            }
            var recipeModel = await _context.Recipes.FindAsync(id);

            if (recipeModel == null)
            {
                return NotFound();
            }

            return recipeModel;
        }

        // POST: api/Recipe
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecipeModel>> PostRecipeModel(CreateRecipeModel createRecipeModel)
        {
            if (_context.Recipes == null)
            {
                return Problem("Entity set 'CulinuContext.Recipes'  is null.");
            }
            var ingredients = createRecipeModel.Ingredients;


            foreach (var userIngredient in createRecipeModel.Ingredients)
            {
                if (!ingredients.Contains(userIngredient))
                {
                    var ingredientModel = new IngredientModel
                    {
                        Name = userIngredient.Name,
                        Unit = userIngredient.Unit,
                        Amount = userIngredient.Amount
                    };

                    _context.Ingredients?.Add(ingredientModel);
                    await _context.SaveChangesAsync();
                }
            }
            RecipeModel recipeModel;

            if (createRecipeModel.Descriptions != null)
                recipeModel = new RecipeModel
                {
                    Ingredients = createRecipeModel.Ingredients,
                    Name = createRecipeModel.Name,
                    Descriptions = createRecipeModel.Descriptions
                };
            else
                recipeModel = new RecipeModel
                {
                    Ingredients = createRecipeModel.Ingredients,
                    Name = createRecipeModel.Name
                };

            _context.Recipes.Add(recipeModel);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipeModel", new { id = recipeModel.Id }, recipeModel);
        }

        // DELETE: api/Recipe/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeModel(int id)
        {
            if (_context.Recipes == null)
            {
                return NotFound();
            }
            var recipeModel = await _context.Recipes.FindAsync(id);

            if (recipeModel == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
