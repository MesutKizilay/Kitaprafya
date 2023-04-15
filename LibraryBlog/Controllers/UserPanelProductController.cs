using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace LibraryBlog.Controllers
{
    public class UserPanelProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        ProductsOfUserManager productsOfUserManager = new ProductsOfUserManager(new EfProductsOfUserDal());
        ProductsOfUser productsOfUser = new ProductsOfUser();
        ShareManager shareManager = new ShareManager(new EfShareDal());
        LibraryBlogContext libraryBlogContext = new LibraryBlogContext();
        ProductValidator productValidator = new ProductValidator();

        // GET: UserPanel
        public ActionResult Index(string p, int pageNo = 1)
        {
            var productValues = from d in libraryBlogContext.Products select d;
            if (!string.IsNullOrEmpty(p))
            {
                productValues = productValues.Where(x => x.ProductName.Contains(p));
            }
            return View(productValues.ToList().ToPagedList(pageNo, 4));
            //var productValues = productManager.GetList();
            //return View(productValues);
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

            ValidationResult result = productValidator.Validate(product);
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

        public ActionResult AddToMyBooks(int id)
        {
            if (productsOfUserManager.HasProduct(id, (int)Session["UserId"]))
            {
                return RedirectToAction("Index", "UserPanelMyBooks");
            }
            else
            {
                productsOfUser.ProductId = id;
                productsOfUser.UserId = (int)Session["UserId"];
                productsOfUserManager.AddProduct(productsOfUser);
                return RedirectToAction("Index", "UserPanelMyBooks");
            }
        }

        public ActionResult ReachBook(int id, string cityId, string districtId)
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

            var productValues = from d in shareManager.GetListByProduct(id, (int)Session["UserId"]) select d/*libraryBlogContext.Shares.Where(x => x.ProductId == id && x.UserId != (int)Session["UserId"]) select d*//*where d.ProductId == id where d.UserId != (int)Session["UserId"] select d*/;
            if (!string.IsNullOrEmpty(cityId))
            {
                if (!string.IsNullOrEmpty(districtId))
                {
                    productValues = productValues.Where(x => x.User.CityId.ToString().Contains(cityId) && x.User.District.DistrictId.ToString() == districtId);
                }
                else
                {
                    productValues = productValues.Where(x => x.User.CityId.ToString().Contains(cityId));
                }

            }

            return View(productValues.ToList());
            //var shareValues = shareManager.GetListByProduct(id,(int)Session["UserId"]);
            //return View(shareValues);
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


        //return PartialView("Modals/_DisLabPartial", result.Data);

        //[HttpGet]
        //public PartialViewResult ReachBookHelper(int id)
        //{
        //    var xxx = Convert.ToInt32(TempData["UserID"]);
        //    requestsOfProduct.ProductId = 1;
        //    requestsOfProduct.RequestUserId = 3;
        //    requestsOfProduct.UserId = xxx;
        //    return PartialView(requestsOfProduct);
        //}

        //[HttpPost]
        //public PartialViewResult ReachBookHelper(RequestsOfProduct requestsOfProduct)
        //{
        //    var xxx = TempData["UserID"];
        //    productsOfUserManager.AddProduct(productsOfUser);
        //    return PartialView();
        //}
    }
}