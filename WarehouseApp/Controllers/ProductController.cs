using Microsoft.AspNetCore.Mvc;
using WarehouseApp.Models;

namespace WarehouseApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            WarehouseAppContext context = HttpContext.RequestServices.GetService(typeof(WarehouseAppContext)) as WarehouseAppContext;

            return View(context.GetAllProducts());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Product product)
        {
            WarehouseAppContext context = HttpContext.RequestServices.GetService(typeof(WarehouseAppContext)) as WarehouseAppContext;
            if(ModelState.IsValid){
                context.CreateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}