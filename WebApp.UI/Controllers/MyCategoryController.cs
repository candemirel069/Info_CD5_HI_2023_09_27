using Microsoft.AspNetCore.Mvc;
using WebApp.BL.Repository;
using WebApp.Data.Entities;

namespace WebApp.UI.Controllers
{
    public class MyCategoryController : Controller
    {
        private readonly CategoryRepository _categoryRepo;

        public MyCategoryController(CategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            return View(_categoryRepo.GetAll().OrderBy(x=>x.Name));
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Category model)
        {
            _categoryRepo.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_categoryRepo.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(Category model)
        {
            _categoryRepo.Update(model);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _categoryRepo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
