using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IShareService
    {
        List<Share> GetList(int sessionId);
        List<Share> GetListByProduct(int id, int sesionId);
        void AddProduct(Share share);
        Share GetById(int id, int sesionId);
        void DeleteProduct(Share share);
        bool HasProduct(int id, int sesionId);
    }
}
