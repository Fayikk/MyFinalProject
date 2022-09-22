using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _ıuserDal;
        public UserManager(IUserDal ıuserDal)
        {
            _ıuserDal = ıuserDal;
        }
        public void Add(User user)
        {
             _ıuserDal.Add(user);
        }

        public User GetByMail(string mail)
        {
            return _ıuserDal.Get(a => a.Email == mail);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _ıuserDal.GetClaims(user);
        }
    }
}
