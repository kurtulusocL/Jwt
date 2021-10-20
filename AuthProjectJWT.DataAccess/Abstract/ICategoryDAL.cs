using AuthProjectJWT.Core.DataAccess;
using AuthProjectJWT.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProjectJWT.DataAccess.Abstract
{
    public interface ICategoryDAL : IEntityRepository<Category>
    {
    }
}
