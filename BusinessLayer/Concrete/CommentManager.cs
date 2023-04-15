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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void AddComment(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public List<Comment> GetList()
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            return _commentDal.Get(x => x.CommentId == id);
        }

        public List<Comment> GetListByProduct(int id)
        {
            return _commentDal.GetAll(x=>x.ProductId == id);
        }
    }
}
