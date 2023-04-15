using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    
    public class HistoryOfProductManager:IHistoryOfProductService
    {
        IHistoryOfProductDal _historyOfProductDal;
        public HistoryOfProductManager(IHistoryOfProductDal historyOfProductDal)
        {
            _historyOfProductDal = historyOfProductDal;
        }

        public void AddHistory(HistoryOfProduct historyOfProduct)
        {
            _historyOfProductDal.Add(historyOfProduct);
        }

        public HistoryOfProduct GetById(int productId, int userId, int sessionId)
        {
            return _historyOfProductDal.Get(x => x.ProductId == productId && x.UserId == userId && x.OwnerUserId == sessionId);
        }

        public List<HistoryOfProduct> GetList(int sessionId)
        {
            return _historyOfProductDal.GetAll(x => x.OwnerUserId == sessionId && x.HistoryStatus == false);
        }

        public bool HasProduct(int productId, int userId,int sesionId)
        {
            HistoryOfProduct historyOfProduct = _historyOfProductDal.Get(x => x.ProductId == productId && x.UserId == userId && x.OwnerUserId == sesionId);
            if (historyOfProduct != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateHistory(HistoryOfProduct historyOfProduct)
        {
            _historyOfProductDal.Update(historyOfProduct);
        }
    }
}
