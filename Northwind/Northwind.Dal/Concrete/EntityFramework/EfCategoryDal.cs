using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Dal.Abstract;
using Northwind.Entities;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EfCategoryDal : ICategoryDal
    {
        private NorthwindContext _context = new NorthwindContext();

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

       
    }
}
