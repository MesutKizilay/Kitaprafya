using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService
    {
        List<Product> GetList();
        List<Product> GetListByCategory(int id);
        List<Product> GetListByWriter(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        Product GetById(int id);
        void DeleteProduct(Product product);
    }
}
