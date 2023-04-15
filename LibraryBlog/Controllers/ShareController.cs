using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryBlog.Controllers
{
    public class ShareController : Controller
    {
        ShareManager shareManager = new ShareManager(new EfShareDal());
        // GET: Share
        public ActionResult Index()
        {
            var shareValues = shareManager.GetList((int)Session["UserId"]);
            return View(shareValues);
        }

        public ActionResult DeleteProduct(int id)
        {
            var productValues = shareManager.GetById(id,(int)Session["UserId"]);
            shareManager.DeleteProduct(productValues);
            return RedirectToAction("Index");
        }
    }
}