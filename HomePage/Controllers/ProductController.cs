using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HomePage.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            var result = _productService.GetAll();
            return View(result);
        }
    }
}
