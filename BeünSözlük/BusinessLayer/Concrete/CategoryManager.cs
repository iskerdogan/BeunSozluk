using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public void AddCategoryBusinessLayer(Category category)
        {
            _categoryDal.Add(category);

        }

        public Category GetCategoryById(int id)
        {
            return _categoryDal.Get(x=>x.CategoryId==id);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Update(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public List<Category> GetListBySearch(string search)
        {
            return _categoryDal.List(x => x.CategoryName.Contains(search));
        }
    }
}
