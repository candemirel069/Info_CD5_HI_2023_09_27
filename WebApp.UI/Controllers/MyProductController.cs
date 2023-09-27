using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.BL.Repository;
using WebApp.Data.Entities;

namespace WebApp.UI.Controllers
{
    public class MyProductController : Controller
    {
        private readonly ProductRepository _prodRepository;
        private readonly CategoryRepository _categoryRepository;

        public MyProductController(ProductRepository prodRepository, CategoryRepository categoryRepository)
        {
            _prodRepository = prodRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View(_prodRepository.GetAll());
        }

        public IActionResult Create()
        {
            var catList= _categoryRepository.GetAll();
            ViewData["CategoryId"] = new SelectList(catList, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            return RedirectToAction("Index");
        }
    }
}
