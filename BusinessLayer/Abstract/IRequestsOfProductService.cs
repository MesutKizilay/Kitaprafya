using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRequestsOfProductService
    {
        List<RequestsOfProduct> GetListByUser(int sessionId);
        List<RequestsOfProduct> GetListByUserMyRequests(int sessionId);
        void AddRequest(RequestsOfProduct request);
        void UpdateRequest(RequestsOfProduct request);
        bool HasProduct(int productId,int userId,int sessionId);
        RequestsOfProduct GetById(int productId, int userId, int sessionId);
    }
}
