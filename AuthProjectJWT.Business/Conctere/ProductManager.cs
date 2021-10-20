using AuthProjectJWT.Business.Abstract;
using AuthProjectJWT.Business.BusinessAspect.Autofac;
using AuthProjectJWT.Business.Constant;
using AuthProjectJWT.Business.ValidationRules.FluentValidation;
using AuthProjectJWT.Core.Autofac.Caching;
using AuthProjectJWT.Core.Autofac.Logging;
using AuthProjectJWT.Core.Autofac.Performance;
using AuthProjectJWT.Core.Autofac.Transaction;
using AuthProjectJWT.Core.Autofac.Validation;
using AuthProjectJWT.Core.CrossCuttingConcern.Logging.Log4net.Loggers;
using AuthProjectJWT.Core.Utilities.Business;
using AuthProjectJWT.Core.Utilities.Results;
using AuthProjectJWT.DataAccess.Abstract;
using AuthProjectJWT.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AuthProjectJWT.Business.Conctere
{
    public class ProductManager : IProductService
    {
        private IProductDAL _productDal;
        private ICategoryService _categoryService;

        public ProductManager(IProductDAL productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
        }

        [PerformanceAspect(5)]
        public IDataResult<List<Product>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }

        //[SecuredOperation("Product.List,Admin")]
        [LogAspect(typeof(FileLogger))]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(p => p.CategoryId == categoryId).ToList());
        }


        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.Name), CheckIfCategoryIsEnabled());

            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        private IResult CheckIfProductNameExists(string productName)
        {

            var result = _productDal.GetList(p => p.Name == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCategoryIsEnabled()
        {
            var result = _categoryService.GetList();
            if (result.Data.Count < 10)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(Product product)
        {

            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
            _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
