using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Culinu.Backend;
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
        public async Task<ActionResult<IEnumerable<RecipeModel>>> GetRecipes()
        {
            if (_context.Recipes == null)
            {
                return NotFound();
            }
            var section = _context.Recipes.Include(s => s.Ingredients);
            
            return await _context.Recipes
                .Include(s => s.Ingredients)
                .ToListAsync();
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

            var recipeModel = new RecipeModel
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
