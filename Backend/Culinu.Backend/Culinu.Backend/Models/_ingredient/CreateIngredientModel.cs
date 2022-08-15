using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Culinu.Backend.Models
{
    public class CreateIngredientModel
    {
        public string? Name { get; set; } = default!;
        public int? Amount { get; set; }
        public string? Unit { get; set; }
    }
}
