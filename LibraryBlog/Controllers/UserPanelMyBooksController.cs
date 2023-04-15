using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryBlog.Controllers
{
    public class UserPanelMyBooksController : Controller
    {
        ProductsOfUserManager productsOfUserManager = new ProductsOfUserManager(new EfProductsOfUserDal());
        ShareManager shareManager = new ShareManager(new EfShareDal());
        Share share = new Share();
        // GET: Default
        public ActionResult Index()
        {
            int sessionId=(int)Session["UserId"];
            var productValues = productsOfUserManager.GetList(sessionId);
            return View(productValues);
        }

        public ActionResult DeleteProduct(int id)
        {
            var productValues = productsOfUserManager.GetById(id, (int)Session["UserId"]);
            productsOfUserManager.DeleteProduct(productValues);
            return RedirectToAction("Index");
        }

        public ActionResult ShareMyBook(int id)
        {
            if (shareManager.HasProduct(id, (int)Session["UserId"]))
            {
                return RedirectToAction("Index", "Share");
            }
            else
            {
                share.ProductId = id;
                share.UserId = (int)Session["UserId"];
                shareManager.AddProduct(share);
                return RedirectToAction("Index", "Share");
            }
        }
    }
}