using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeünSözlük.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        // GET: Default
        public ActionResult Headings(string search)
        {
            var headingList = !string.IsNullOrEmpty(search) ? headingManager.GetListBySearch(search).Where(x => x.HeadingStatus == true).ToList() : headingManager.GetList().Where(x => x.HeadingStatus == true).ToList();
            return View(headingList);
        }

        public PartialViewResult Index(int id = 0,int page = 1)
        {
            var contentLis = contentManager.GetListByHeadingId(id).ToPagedList(page, 4);
            return PartialView(contentLis);
        }

        public ActionResult GetAllContent(string search)
        {
            var values = !string.IsNullOrEmpty(search) ? contentManager.GetListBySearch(search) : contentManager.GetList();
            return View(values);
        }

    }
}