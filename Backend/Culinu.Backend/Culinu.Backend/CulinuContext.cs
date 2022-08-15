using Culinu.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Culinu.Backend
{
    public class CulinuContext : DbContext
    {
        public CulinuContext(DbContextOptions<CulinuContext> options)
            : base(options)
        {
        }

        public DbSet<IngredientModel>? Ingredients { get; set; }
        public DbSet<RecipeModel>? Recipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=Culinu;Username=postgres;Password=postgres");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientModel>().ToTable("Ingredient");
            modelBuilder.Entity<RecipeDescription>().ToTable("RecipeDescription");
            modelBuilder.Entity<RecipeModel>().HasMany(x => x.Ingredients);
            modelBuilder.Entity<RecipeModel>().ToTable("Recipe").HasMany(x => x.Descriptions);
           
        }
    }
}
