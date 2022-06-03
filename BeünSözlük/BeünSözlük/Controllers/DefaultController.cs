using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
        public ActionResult Headings()
        {
            var headingList = headingManager.GetList();
            return View(headingList);
        }

        public PartialViewResult Index(int id=0)
        {
            var contentLis= contentManager.GetListByHeadingId(id);
            return PartialView(contentLis);
        }
    }
}