using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal productDal;

        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(productDal.Get(a => a.ProductId == id));
        }
        // 1 min of cache activated here
        [CacheAspect(duration:1)]
        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(productDal.GetList().ToList());
        }

        [PerformanceAspect(5)]
        [SecuredOperations("Product.List,Admin")]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(productDal.GetList(a => a.CategoryId == categoryId).ToList());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }
        public IResult Update(Product product)
        {
            productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
        [TransactionScopeAspect]
        public IResult Transaction(Product product)
        {
            productDal.Update(product);
            productDal.Add(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
