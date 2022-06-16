using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BeünSözlük.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        // GET: Register
        [HttpGet]
        public ActionResult WriterRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterRegister(Writer writer)
        {
            if (!ModelState.IsValid)
            {
                return View("WriterRegister");
            }
            writer.WriterImage = "https://i.hizliresim.com/m7hjvhh.jpg";
            writerManager.WriterAdd(writer);
            return RedirectToAction("WriterLogin", "Login");
        }
    }
}