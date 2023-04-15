using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductsOfUserService
    {
        List<ProductsOfUser> GetList(int sessionId);
        void AddProduct(ProductsOfUser productsOfUser);
        void DeleteProduct(ProductsOfUser productsOfUser);
        ProductsOfUser GetById(int id, int sessionId);
        bool HasProduct(int id, int sessionId);
    }
}
