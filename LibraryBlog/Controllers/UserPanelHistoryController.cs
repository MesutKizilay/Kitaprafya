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
    public class UserPanelHistoryController : Controller
    {
        HistoryOfProductManager historyOfProductManager = new HistoryOfProductManager(new EfHistoryOfProductDal());
        RequestsOfProductManager requestOfProductManager = new RequestsOfProductManager(new EfRequestsOfProductDal());
        // GET: UserPanelHistory
        public ActionResult Index()
        {
            DateTime nowDate=DateTime.Now;
            ViewBag.NowDate = nowDate;
            var historyValues = historyOfProductManager.GetList((int)Session["UserId"]);
            return View(historyValues);
        }

        public ActionResult AddHistory(int _UserId, int _ProductId)
        {
            var requestValues=requestOfProductManager.GetById(_ProductId, (int)Session["UserId"], _UserId);
            requestValues.RequestStatus = true;
            requestOfProductManager.UpdateRequest(requestValues);

            if (historyOfProductManager.HasProduct(_ProductId, _UserId, (int)Session["UserId"]))
            {
                return RedirectToAction("Index");
            }
            else
            {
                HistoryOfProduct historyOfProduct = new HistoryOfProduct();
                historyOfProduct.ShareDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
                historyOfProduct.ProductId = _ProductId;
                historyOfProduct.UserId = _UserId;
                historyOfProduct.OwnerUserId = (int)Session["UserId"];
                historyOfProductManager.AddHistory(historyOfProduct);
                return RedirectToAction("Index");
            }
        }

        public ActionResult DeleteHistory(int _UserId, int _ProductId)
        {
            var historyValues=historyOfProductManager.GetById(_ProductId,_UserId, (int)Session["UserId"]);
            var requestValues=requestOfProductManager.GetById(_ProductId, (int)Session["UserId"],_UserId);
            historyValues.HistoryStatus = true;
            requestValues.HistoryStatus = true;
            historyOfProductManager.UpdateHistory(historyValues);
            requestOfProductManager.UpdateRequest(requestValues);
            return RedirectToAction("Index");
        }
    }
}