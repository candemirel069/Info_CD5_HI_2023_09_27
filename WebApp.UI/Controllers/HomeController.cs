using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Data.Entities;
using WebApp.UI.Models;

namespace WebApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyShopContext _context;

        public HomeController(MyShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cat1 = new Category { Name = "Bilim Kurgu" };

            var prod1 = new Product { 
                Name="Zaman Makinası", 
                Category= cat1, 
                Length=10, 
                Description= "açıklama açıklama "
            };

            //_context.Products.Add(prod1);
            _context.Add(prod1);
            _context.SaveChanges();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}