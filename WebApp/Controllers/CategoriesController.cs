using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        // List all categories
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }

        // Add category (GET and POST)
        [HttpGet]
        public IActionResult Add(int? id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            CategoriesRepository.AddCategory(category);
            return RedirectToAction("Index");
        }

        // Edit category (GET and POST)
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var category = CategoriesRepository.GetCategoryById(id ?? 0);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // Delete category (POST)
        [HttpPost]
        public IActionResult Delete(int id)
        {
            CategoriesRepository.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
