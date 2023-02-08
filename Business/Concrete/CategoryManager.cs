using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _category;
        public CategoryManager(ICategoryDal category)
        {
            _category = category;
        }

        public List<Category> GetAll()
        {
            return _category.GetAll();
        }

        public Category GetAllById(int categoryId)
        {
            return _category.Get(c => c.CategoryId == categoryId);
        }
    }
}
