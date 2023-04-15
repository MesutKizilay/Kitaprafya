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
    public class UserPanelRequestController : Controller
    {
        RequestsOfProductManager requestsOfProductManager = new RequestsOfProductManager(new EfRequestsOfProductDal());
        HistoryOfProductManager historyOfProductManager = new HistoryOfProductManager(new EfHistoryOfProductDal());
        UserManager userManager = new UserManager(new EfUserDal());
        RequestsOfProductValidator requestsOfProductValidator = new RequestsOfProductValidator();
        //Usermanager usermanager = new Usermanager(new EfUserDal());
        // GET: UserPanelRequest
        public ActionResult Index()
        {
            var requestValues = requestsOfProductManager.GetListByUser((int)Session["UserId"]);
            return View(requestValues);
        }

        public ActionResult MyRequests()
        {
            List<User> users = new List<User>();
            var requestValues = requestsOfProductManager.GetListByUserMyRequests((int)Session["UserId"]);
            var userValues = userManager.GetList((int)Session["UserId"]);

            foreach (var request in requestValues)
            {
                foreach (var user in userValues)
                {
                    if (request.OwnerUserId == user.UserId)
                    {
                        users.Add(user);
                    }
                }
            }

            ViewBag.users = users;
            return View(requestValues);
        }

        [HttpGet]
        public ActionResult AddRequest(int _UserId, int _ProductId)
        {
            RequestsOfProduct requestsOfProduct = new RequestsOfProduct();
            requestsOfProduct.OwnerUserId = _UserId;
            requestsOfProduct.UserId = (int)Session["UserId"];
            requestsOfProduct.ProductId = _ProductId;
            return View(requestsOfProduct);
        }

        [HttpPost]
        public ActionResult AddRequest(RequestsOfProduct requestsOfProduct)
        {
            ValidationResult result = requestsOfProductValidator.Validate(requestsOfProduct);
            if (result.IsValid)
            {
                var values = requestsOfProductManager.GetById(requestsOfProduct.ProductId, requestsOfProduct.OwnerUserId, (int)Session["UserId"]);
                if (requestsOfProductManager.HasProduct(requestsOfProduct.ProductId, requestsOfProduct.OwnerUserId, (int)Session["UserId"]))
                {
                    values.RequestNote = requestsOfProduct.RequestNote;
                    requestsOfProductManager.UpdateRequest(values);
                    return RedirectToAction("MyRequests", "UserPanelRequest"/*, new { id = requestsOfProduct.ProductId }*/ /*new { id = requestsOfProduct./*Owner UserId }*/);
                }
                else
                {
                    requestsOfProductManager.AddRequest(requestsOfProduct);
                    return RedirectToAction("MyRequests", "UserPanelRequest"/*, new {id=requestsOfProduct.ProductId}*/ /*new { id = requestsOfProduct./*Owner UserId }*/);
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}