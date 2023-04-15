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
    public class ShareManager : IShareService
    {
        IShareDal _shareDal;

        public ShareManager(IShareDal shareDal)
        {
            _shareDal = shareDal;
        }

        public void AddProduct(Share share)
        {
            _shareDal.Add(share);
        }

        public void DeleteProduct(Share share)
        {
            _shareDal.Delete(share);
        }

        public Share GetById(int id, int sesionId)
        {
            return _shareDal.Get(x => x.ProductId == id && x.UserId == sesionId);
        }

        public List<Share> GetList(int sessionId)
        {
            return _shareDal.GetAll(x=>x.UserId== sessionId);
        }

        public List<Share> GetListByProduct(int id,int sesionId)
        {
            return _shareDal.GetAll(x => x.ProductId == id && x.UserId != sesionId);
        }

        public bool HasProduct(int id, int sesionId)
        {
            Share share = _shareDal.Get(x => x.ProductId == id && x.UserId == sesionId);
            if (share != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
