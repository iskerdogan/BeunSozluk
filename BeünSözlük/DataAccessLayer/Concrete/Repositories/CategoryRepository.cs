using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context context = new Context();
        DbSet<Category> categories;
        public void Add(Category category)
        {
            categories.Add(category);
            context.SaveChanges();
        }

        public void Delete(Category category)
        {
            categories.Remove(category);
            context.SaveChanges();
        }

        public List<Category> List()
        {
            return categories.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            context.SaveChanges();
        }
    }
}
