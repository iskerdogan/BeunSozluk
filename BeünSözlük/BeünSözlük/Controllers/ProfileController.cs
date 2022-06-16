using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeünSözlük.Controllers
{
    public class ProfileController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        AdminValidator validationRules = new AdminValidator();
        Context context = new Context();
        // GET: Profile

        [HttpGet]
        public ActionResult AdminProfile(int id = 0)
        {
            string adminUserName = (string)Session["AdminUserName"];
            id = context.Admins.Where(x => x.AdminUserName == adminUserName).Select(x => x.Id).FirstOrDefault();
            var adminValue = adminManager.GetAdminById(id);
            return View(adminValue);
        }

        [HttpPost]
        public ActionResult AdminProfile(Admin admin)
        {
            ValidationResult validationResult = validationRules.Validate(admin);
            if (validationResult.IsValid)
            {
                adminManager.AdminUpdate(admin);
                return RedirectToAction("AdminProfile");
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
    }
}