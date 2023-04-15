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
    public class RequestsOfProductManager : IRequestsOfProductService
    {
        IRequestsOfProductDal _requestOfProductDal;

        public RequestsOfProductManager(IRequestsOfProductDal requestOfProductDal)
        {
            _requestOfProductDal = requestOfProductDal;
        }

        public void AddRequest(RequestsOfProduct request)
        {
            _requestOfProductDal.Add(request);
        }

        public RequestsOfProduct GetById(int productId, int userId,int sessionId)
        {
            return _requestOfProductDal.Get(x => x.ProductId == productId && x.UserId == sessionId && x.OwnerUserId == userId);
        }

        public List<RequestsOfProduct> GetListByUser(int sessionId)
        {
            return _requestOfProductDal.GetAll(x => x.OwnerUserId == sessionId);
        }

        public List<RequestsOfProduct> GetListByUserMyRequests(int sessionId)
        {
            return _requestOfProductDal.GetAll(x => x.UserId == sessionId);
        }

        public bool HasProduct(int productId,int userId, int sessionId)
        {
            RequestsOfProduct requestOfProduct = _requestOfProductDal.Get(x => x.ProductId == productId && x.UserId == sessionId && x.OwnerUserId == userId);
            if (requestOfProduct != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateRequest(RequestsOfProduct request)
        {
            _requestOfProductDal.Update(request);
        }
    }
}