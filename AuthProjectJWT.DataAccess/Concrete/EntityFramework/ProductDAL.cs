using AuthProjectJWT.Core.DataAccess.EntityFramework;
using AuthProjectJWT.DataAccess.Abstract;
using AuthProjectJWT.DataAccess.Concrete.EntityFramework.Context;
using AuthProjectJWT.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProjectJWT.DataAccess.Concrete.EntityFramework
{
    public class ProductDAL: EfEntityRepositoryBase<Product, ApplicationDbContext>, IProductDAL
    {
    }
}
