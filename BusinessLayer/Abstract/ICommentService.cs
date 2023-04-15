using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetList();
        List<Comment> GetListByProduct(int id);
        Comment GetById(int id);
        void AddComment(Comment comment);
    }
}
