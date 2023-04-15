using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryBlog.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        UserLoginManager userLoginManager = new UserLoginManager(new EfUserDal());
        LibraryBlogContext libraryBlogContext = new LibraryBlogContext();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            LibraryBlogContext context = new LibraryBlogContext();
            var userInfo = context.Users.FirstOrDefault
                (x => x.UserName == user.UserName && x.UserPassword == user.UserPassword&&x.UserRole=="B");
            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.UserName, false);
                Session["UserName"] = userInfo.UserName;
                Session["UserID"] = userInfo.UserId;
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult UserLogin(string cityId)
        {
            List<SelectListItem> _valueCity = (from x in libraryBlogContext.Cities
                                                orderby x.CityName ascending
                                                select new SelectListItem
                                                {
                                                    Text = x.CityName,
                                                    Value = x.CityId.ToString()
                                                }).ToList();

            List<SelectListItem> _valueDistrict = (from x in libraryBlogContext.Districts
                                                   orderby x.DistrictName ascending
                                                   where x.CityId.ToString() == cityId
                                                   select new SelectListItem
                                                   {
                                                       Value = x.DistrictId.ToString(),
                                                       Text = x.DistrictName
                                                   }).ToList();
            ViewBag.valueCity = _valueCity;
            ViewBag.valueDistrict = _valueDistrict;
            return View();
        }

        public JsonResult Districts(int p)
        {
            List<SelectListItem> _valueDistrict = (from x in libraryBlogContext.Districts
                                                   join y in libraryBlogContext.Cities on x.CityId equals y.CityId
                                                   where x.CityId == p
                                                   //orderby x.DistrictName ascending
                                                   select new SelectListItem
                                                   {
                                                       Text = x.DistrictName,
                                                       Value = x.DistrictId.ToString()

                                                   }).ToList();

            return Json(_valueDistrict, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UserLogin(User user)
        {
            var userInfo = userLoginManager.GetUser(user.UserMail, user.UserPassword);
            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.UserMail, false);
                Session["UserMail"] = userInfo.UserMail;
                Session["UserName"] = userInfo.UserName+" "+userInfo.UserSurName;
                Session["UserID"] = userInfo.UserId;
                return RedirectToAction("Index", "UserPanelProduct");
            }
            else
            {
                return RedirectToAction("UserLogin");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("UserLogin");
        }
    }
}