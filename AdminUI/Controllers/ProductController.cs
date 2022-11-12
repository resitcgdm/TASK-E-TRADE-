using Business.Abstract;
using Business.ValidationRules;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AdminUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService=productService;
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {

            ProductValidation productValid = new ProductValidation();
            ValidationResult results = productValid.Validate(product);
            if(results.IsValid)
            {
                _productService.Add(product);
                return View();
                

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();


        }
        public IActionResult DeleteProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteProduct(Product product)
        {
            _productService.Delete(product);
            return View();
        }
        public IActionResult UpdateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            ProductValidation productValid = new ProductValidation();
            ValidationResult results = productValid.Validate(product);
            if(results.IsValid)
            {
                _productService.Update(product);
                return View();
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
       
        [Authorize(Roles  = "Admin")]
        public IActionResult List()
        {
            var result = _productService.GetAll();
            return View(result);
        }

       
        public IActionResult DeleteById(int id)
        {
            var ent = _productService.GetId(id);
            _productService.Delete(ent);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult GetAllByCategoryId()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult GetAllByCategoryId(int id)
        {
            _productService.GetAllByCategoryId(id);
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
