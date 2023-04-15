using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryBlog.Controllers
{
    public class UserPanelProfileController : Controller
    {
        UserManager userManager = new UserManager(new EfUserDal());
        // GET: UserPaneProfile
        public ActionResult Index()
        {
            var userValues = userManager.GetById((int)Session["UserId"]);
            return View(userValues);
        }
    }
}