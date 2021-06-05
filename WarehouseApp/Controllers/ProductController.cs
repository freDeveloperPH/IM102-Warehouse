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

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            WarehouseAppContext context = HttpContext.RequestServices.GetService(typeof(WarehouseAppContext)) as WarehouseAppContext;
            Product product = context.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] Product product)
        {
            WarehouseAppContext context = HttpContext.RequestServices.GetService(typeof(WarehouseAppContext)) as WarehouseAppContext;
            if(ModelState.IsValid){
                context.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
             if (id == null)
            {
                return NotFound();
            }
            WarehouseAppContext context = HttpContext.RequestServices.GetService(typeof(WarehouseAppContext)) as WarehouseAppContext;
            Product product = context.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        
        [HttpGet]
        public IActionResult Delete(int? id)
        {
             if (id == null)
            {
                return NotFound();
            }
            WarehouseAppContext context = HttpContext.RequestServices.GetService(typeof(WarehouseAppContext)) as WarehouseAppContext;
            Product product = context.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            WarehouseAppContext context = HttpContext.RequestServices.GetService(typeof(WarehouseAppContext)) as WarehouseAppContext;
            context.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}