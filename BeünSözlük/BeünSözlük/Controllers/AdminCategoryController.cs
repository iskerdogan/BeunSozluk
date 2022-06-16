using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeünSözlük.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());


        public ActionResult Index(string search,int page = 1)
        {
            var categoryValues = !string.IsNullOrEmpty(search) ? categoryManager.GetListBySearch(search).ToPagedList(page, 10) : categoryManager.GetList().ToPagedList(page, 11);
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult validationResult = validationRules.Validate(category);
            if (validationResult.IsValid)
            {
                categoryManager.AddCategoryBusinessLayer(category);
                return  RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryValue= categoryManager.GetCategoryById(id);
            categoryValue.CategoryStatus = categoryValue.CategoryStatus ? false : true;
            categoryManager.CategoryDelete(categoryValue);
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = categoryManager.GetCategoryById(id);
            return View(categoryValue); 
        }
        
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            categoryManager.CategoryUpdate(category);
            return RedirectToAction("Index"); 
        }
    }
}