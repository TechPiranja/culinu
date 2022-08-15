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
    public class IngredientController : ControllerBase
    {
        private readonly CulinuContext _context;

        public IngredientController(CulinuContext context)
        {
            _context = context;
        }

        // GET: api/Ingredient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientModel>>> GetIngredients()
        {
          if (_context.Ingredients == null)
          {
              return NotFound();
          }
            return await _context.Ingredients.ToListAsync();
        }

        // GET: api/Ingredient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientModel>> GetIngredientModel(int id)
        {
          if (_context.Ingredients == null)
          {
              return NotFound();
          }
            var ingredientModel = await _context.Ingredients.FindAsync(id);

            if (ingredientModel == null)
            {
                return NotFound();
            }

            return ingredientModel;
        }

        // POST: api/Ingredient
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateIngredientModel>> PostIngredientModel(CreateIngredientModel createIngredientModel)
        {
          if (_context.Ingredients == null)
          {
              return Problem("Entity set 'CulinuContext.Ingredients'  is null.");
          }

            var ingredientModel = new IngredientModel
            {
                Name = createIngredientModel.Name
            };

            _context.Ingredients.Add(ingredientModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredientModel", new { id = ingredientModel.Id }, ingredientModel);
        }

        // DELETE: api/Ingredient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredientModel(int id)
        {
            if (_context.Ingredients == null)
            {
                return NotFound();
            }
            var ingredientModel = await _context.Ingredients.FindAsync(id);
            if (ingredientModel == null)
            {
                return NotFound();
            }

            _context.Ingredients.Remove(ingredientModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
