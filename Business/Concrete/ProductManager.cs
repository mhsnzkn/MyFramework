using Business.Abstract;
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

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(productDal.GetList().ToList());
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(productDal.GetList(a => a.CategoryId == categoryId).ToList());
        }

        public IResult Add(Product product)
        {
            productDal.Add(product);
            return new SuccessResult("Urun basariyla eklendi");
        }

        public IResult Delete(Product product)
        {
            productDal.Delete(product);
            return new SuccessResult("Urun basariyla silindi");
        }
        public IResult Update(Product product)
        {
            productDal.Update(product);
            return new SuccessResult("Urun basariyla Guncellendi");
        }
    }
}
