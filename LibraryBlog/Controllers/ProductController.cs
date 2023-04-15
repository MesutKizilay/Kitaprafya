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
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        ProductValidator productValidator = new ProductValidator();
        // GET: Product
        public ActionResult Index()
        {
            var productValues = productManager.GetList();
            return View(productValues);
        }

        public ActionResult ProductByCategory(int id)
        {
            var values = productManager.GetListByCategory(id);
            return View(values);
        }

        public ActionResult ProductByWriter(int id)
        {
            var values = productManager.GetListByWriter(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> _valueCategory = (from x in productManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Category.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();

            List<SelectListItem> _valueWriter = (from x in writerManager.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Value = x.WriterId.ToString(),
                                                     Text = x.WriterName + " " + x.WriterSurname
                                                 }).ToList();

            ViewBag.valueCategory = _valueCategory;
            ViewBag.valueWriter = _valueWriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            ValidationResult result = productValidator.Validate(product);

            List<SelectListItem> _valueCategory = (from x in productManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Category.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();

            List<SelectListItem> _valueWriter = (from x in writerManager.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Value = x.WriterId.ToString(),
                                                     Text = x.WriterName + " " + x.WriterSurname
                                                 }).ToList();

            ViewBag.valueCategory = _valueCategory;
            ViewBag.valueWriter = _valueWriter;

            if (result.IsValid)
            {
                productManager.AddProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(product);
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var productValues = productManager.GetById(id);
            List<SelectListItem> _valueCategory = (from x in productManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Category.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();

            List<SelectListItem> _valueWriter = (from x in writerManager.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Value = x.WriterId.ToString(),
                                                     Text = x.WriterName + " " + x.WriterSurname
                                                 }).ToList();

            ViewBag.valueCategoryForEdit = _valueCategory;
            ViewBag.valueWriterForEdit = _valueWriter;
            return View(productValues);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            productManager.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var productValues = productManager.GetById(id);
            productManager.DeleteProduct(productValues);
            return RedirectToAction("Index");
        }
    }
}