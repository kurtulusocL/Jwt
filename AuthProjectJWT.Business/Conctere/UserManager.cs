using AuthProjectJWT.Business.Abstract;
using AuthProjectJWT.Core.Entities.Concrete;
using AuthProjectJWT.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProjectJWT.Business.Conctere
{
    public class UserManager : IUserService
    {
        IUserDAL _userDal;

        public UserManager(IUserDAL userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
