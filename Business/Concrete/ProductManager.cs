using Business.Abstract;
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

        public void Add(Product product)
        {
            productDal.Add(product);
        }

        public void Delete(Product product)
        {
            productDal.Delete(product);
        }

        public Product GetById(int id)
        {
            return productDal.Get(a => a.ProductId == id);
        }

        public List<Product> GetList()
        {
            return productDal.GetList().ToList();
        }

        public List<Product> GetListByCategory(int categoryId)
        {
            return productDal.GetList(a => a.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            productDal.Update(product);
        }
    }
}
