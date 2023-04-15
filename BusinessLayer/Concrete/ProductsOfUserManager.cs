using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public class ProductsOfUserManager : IProductsOfUserService
    {
        IProductsOfUserDal _productsOfUserDal;

        public ProductsOfUserManager(IProductsOfUserDal productsOfUserDal)
        {
            _productsOfUserDal = productsOfUserDal;
        }

        public void AddProduct(ProductsOfUser productsOfUser)
        {
           _productsOfUserDal.Add(productsOfUser);
        }

        public void DeleteProduct(ProductsOfUser productsOfUser)
        {
            _productsOfUserDal.Delete(productsOfUser);
        }

        public ProductsOfUser GetById(int id ,int sessionId)
        {
            return _productsOfUserDal.Get(x => x.ProductId == id && x.UserId == sessionId);
        }

        public List<ProductsOfUser> GetList(int sessionId)
        {
            return _productsOfUserDal.GetAll(x=>x.UserId== sessionId);
        }

        public bool HasProduct(int id, int sessionId)
        {
            ProductsOfUser productsOfUser = _productsOfUserDal.Get(x => x.ProductId == id && x.UserId == sessionId);
            if (productsOfUser!=null)
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