﻿using BusinessLayer.Concrete;
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
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        Context context = new Context();
        // GET: WriterPanel

        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading(string writerMail)
        {
            writerMail = (string)Session["WriterMail"];
            var writerId = context.Writers.Where(x => x.WriterMail == writerMail).Select(x => x.WriterId).FirstOrDefault();
            var values = headingManager.GetListByWriter(writerId);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.valueCategory = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writerMail = (string)Session["WriterMail"];
            var writerId = context.Writers.Where(x => x.WriterMail == writerMail).Select(x => x.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writerId;
            heading.HeadingStatus = true;
            headingManager.AddHeadingBusinessLayer(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.valueCategory = valueCategory;

            var headingValues = headingManager.GetHeadingById(id);
            return View(headingValues);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetHeadingById(id);
            headingValue.HeadingStatus = headingValue.HeadingStatus ? false : true;
            headingManager.HeadingDelete(headingValue);
            return RedirectToAction("MyHeading");
        }
    }
}