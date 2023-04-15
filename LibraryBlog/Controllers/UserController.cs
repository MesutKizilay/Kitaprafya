using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryBlog.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        UserManager userManager = new UserManager(new EfUserDal());
        LibraryBlogContext libraryBlogContext = new LibraryBlogContext();
        // GET: User

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
                user.Country = "Türkiye";
                user.UserRole = "B";
                userManager.AddUser(user);
                return RedirectToAction("UserLogin", "Login");
        }       
    }
}