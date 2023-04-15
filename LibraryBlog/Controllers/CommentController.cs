using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class CommentController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        CommentValidator commnetValidator = new CommentValidator();
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CommentByProduct(int id)
        {
            var values = commentManager.GetListByProduct(id);
            var valueOfProduct = productManager.GetById(id);
            ViewBag.Product = valueOfProduct;
            ViewBag.ProductId=valueOfProduct.ProductId;
            ViewBag.ProductImage=valueOfProduct.ProductImage;
            return View(values);
        }

        public ActionResult GetCommentDetails(int id)
        {
            var commentValues = commentManager.GetById(id);
            return View(commentValues);
        }

        [HttpGet]
        public ActionResult AddComment(int id)
        {
            ViewBag.UserId = (int)Session["UserId"];
            ViewBag.Id = id;
            
            return View();
        }

        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {           
            ValidationResult result = commnetValidator.Validate(comment);

            if (result.IsValid)
            {
                comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
                commentManager.AddComment(comment);
                return RedirectToAction("CommentByProduct", new { id = comment.ProductId });
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