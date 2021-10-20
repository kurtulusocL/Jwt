using AuthProjectJWT.Core.DataAccess.EntityFramework;
using AuthProjectJWT.Core.Entities.Concrete;
using AuthProjectJWT.DataAccess.Abstract;
using AuthProjectJWT.DataAccess.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthProjectJWT.DataAccess.Concrete.EntityFramework
{
    public class UserDAL : EfEntityRepositoryBase<User, ApplicationDbContext>, IUserDAL
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ApplicationDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
