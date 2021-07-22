using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal CategoryDal;

        public CategoryManager(ICategoryDal CategoryDal)
        {
            this.CategoryDal = CategoryDal;
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(CategoryDal.Get(a => a.CategoryId == id));
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(CategoryDal.GetList().ToList());
        }

        public IDataResult<List<Category>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Category>>(CategoryDal.GetList(a => a.CategoryId == categoryId).ToList());
        }

        public IResult Add(Category Category)
        {
            CategoryDal.Add(Category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(Category Category)
        {
            CategoryDal.Delete(Category);
            return new SuccessResult(Messages.CategoryDeleted);
        }
        public IResult Update(Category Category)
        {
            CategoryDal.Update(Category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
