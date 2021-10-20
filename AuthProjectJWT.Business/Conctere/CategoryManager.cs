using AuthProjectJWT.Business.Abstract;
using AuthProjectJWT.Business.Constant;
using AuthProjectJWT.Core.Utilities.Business;
using AuthProjectJWT.Core.Utilities.Results;
using AuthProjectJWT.DataAccess.Abstract;
using AuthProjectJWT.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthProjectJWT.Business.Conctere
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDAL _categoryDAL;
        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public IResult Add(Category category)
        {
            _categoryDAL.Add(category);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Category category)
        {
            _categoryDAL.Delete(category);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDAL.Get(p => p.Id == id));
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoryDAL.GetList().ToList());
        }

        public IResult Update(Category category)
        {
            _categoryDAL.Update(category);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
