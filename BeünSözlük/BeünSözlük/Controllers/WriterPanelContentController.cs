using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeünSözlük.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();
        // GET: WriterPanelContent
        public ActionResult MyContent(string writerMail)
        {
            writerMail = (string)Session["WriterMail"];
            var writerId = context.Writers.Where(x => x.WriterMail == writerMail).Select(x => x.WriterId).FirstOrDefault();
            var contentValues = contentManager.GetListByWriter(writerId);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.Id = id;    
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string writerMail = (string)Session["WriterMail"];
            var writerId = context.Writers.Where(x => x.WriterMail == writerMail).Select(x => x.WriterId).FirstOrDefault();

            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writerId;
            content.ContentStatus = true;

            contentManager.AddContentBusinessLayer(content);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}