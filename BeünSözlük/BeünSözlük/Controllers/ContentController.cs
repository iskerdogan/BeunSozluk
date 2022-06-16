using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeünSözlük.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string search,int page =1)
        {
            var values = !string.IsNullOrEmpty(search) ? contentManager.GetListBySearch(search).ToPagedList(page, 4) : contentManager.GetList().ToPagedList(page, 4);
            return View(values);
        }

        public ActionResult ContentByHeading(int id,int page = 1)
        {
            var contentValues= contentManager.GetListByHeadingId(id).ToPagedList(page, 7);
            return View(contentValues);
        }
    }
}