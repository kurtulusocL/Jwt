using AuthProjectJWT.Core.Utilities.Results;
using AuthProjectJWT.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProjectJWT.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetList();
        IDataResult<Category> GetById(int id);
        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
    }
}
