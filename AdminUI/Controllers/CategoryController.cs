﻿using Business.Abstract;
using Business.ValidationRules;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminUI.Controllers
{
    public class CategoryController : Controller
    {
        
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
        public IActionResult UpdateCategory()
        {
            return View();
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