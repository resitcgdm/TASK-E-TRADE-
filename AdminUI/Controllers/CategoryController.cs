using Business.Abstract;
using Business.ValidationRules;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AdminUI.Controllers
{
    public class CategoryController : Controller
    {
        Context context = new Context();
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
       
        public IActionResult AddCategory()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult AddCategory(Category category)

        {
            CategoryValidation categoryValid = new CategoryValidation();
            ValidationResult results = categoryValid.Validate(category);
            if(results.IsValid)
            {
                _categoryService.Add(category);
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
        public IActionResult DeleteCategory()
        {
            return View();
        }
        [HttpPost]
        //It works if u create view for this!
        public IActionResult DeleteCategory(Category category)
        {
            _categoryService.Delete(category);
            return View();
        }
        [HttpGet]
        public IActionResult DeleteCategoryById(int id)
        {
            var category = _categoryService.GetId(id);
            _categoryService.Delete(category);
            return RedirectToAction("ListCategory");
        }
        [HttpGet]
    
        public IActionResult UpdateCategory(int id)
        {
            var result = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)

        {
            CategoryValidation categoryValid = new CategoryValidation();
            ValidationResult results = categoryValid.Validate(category);
            if(results.IsValid)
            {
                _categoryService.Update(category);
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


        [Authorize(Roles = "Admin")]
        [HttpGet] 
        public IActionResult ListCategory()
        {
            var result = _categoryService.GetAll();
            return View(result);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
