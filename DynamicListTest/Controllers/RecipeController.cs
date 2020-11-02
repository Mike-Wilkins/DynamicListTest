using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicListTest.Models;
using DynamicListTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DynamicListTest.Controllers
{
    public class RecipeController : Controller
    {
        private ApplicationDbContext _db;
        public RecipeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var Lst = ViewBag.data as IEnumerable<DynamicListTest.Models.Recipe>;
            var recipeList = _db.Recipes.Include(m => m.Items).ToList();
            return View(recipeList);
        }

        // GET: Create
        public IActionResult Create()
        {
            var model = new Recipe();
            model.Items.Add(new RecipeItem());
            return View(model);
        }

        // POST: Create
        [HttpPost]
        public IActionResult Create([Bind("Name, Items")] Recipe recipe)
        {
            _db.Add(recipe);
            _db.SaveChanges();
            var recipeList = _db.Recipes.Include(m => m.Items).ToList();
            return View("Index", recipeList);
        }

        [HttpPost]
        public ActionResult AddRecipeItem([Bind("Items")] Recipe recipe)
        {
            recipe.Items.Add(new RecipeItem());
            return PartialView("RecipeItems", recipe);
        }
    }
}
