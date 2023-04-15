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
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void AddProduct(Product product)
        {
            _productDal.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            _productDal.Delete(product);
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p=>p.ProductId==id);
        }

        public List<Product> GetList()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetListByCategory(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId == id);
        }

        public List<Product> GetListByWriter(int id)
        {
            return _productDal.GetAll(p=>p.WriterId==id);
        }

        public void UpdateProduct(Product product)
        {
            _productDal.Update(product);
        }
    }
}
