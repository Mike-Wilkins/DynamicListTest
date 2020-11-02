using DynamicListTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicListTest.Services
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeItem> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS; Initial Catalog=DynamicListDbCore; Integrated Security=True");
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

    }
}
