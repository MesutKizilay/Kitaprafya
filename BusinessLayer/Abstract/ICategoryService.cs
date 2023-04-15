using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        void AddCategory(Category category);
        Category GetById(int id);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
