using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Culinu.Backend.Models
{
    public class RecipeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;
        public string? Name { get; set; } = default!;
        public ICollection<IngredientModel> Ingredients { get; set; } = default!;
    }
}