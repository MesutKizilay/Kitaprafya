using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHistoryOfProductService
    {
        List<HistoryOfProduct> GetList(int sessionId);
        void AddHistory (HistoryOfProduct historyOfProduct);
        bool HasProduct(int productId, int userId,int sesionId);
        HistoryOfProduct GetById(int productId, int userId, int sessionId);
        void UpdateHistory(HistoryOfProduct historyOfProduct);
    }
}
