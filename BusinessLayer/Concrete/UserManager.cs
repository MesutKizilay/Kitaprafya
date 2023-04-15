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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void AddUser(User user)
        {
            _userDal.Add(user);
        }

        public User GetById(int sessionId)
        {
            return _userDal.Get(x => x.UserId == sessionId);
        }

        public List<User> GetList(int sessionId)
        {
            return _userDal.GetAll(x=>x.UserId!=sessionId);
        }
    }
}
