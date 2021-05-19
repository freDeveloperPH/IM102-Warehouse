using Microsoft.AspNetCore.Mvc;

namespace WarehouseApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            WarehouseAppContext context = HttpContext.RequestServices.GetService(typeof(WarehouseAppContext)) as WarehouseAppContext;

            return View(context.GetAllProducts());
        }
    }
}