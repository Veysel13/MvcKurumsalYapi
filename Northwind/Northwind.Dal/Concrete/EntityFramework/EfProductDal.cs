using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Dal.Abstract;
using Northwind.Entities;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        private NorthwindContext _context=new NorthwindContext();
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int productId)
        {
            _context.Products.Remove(_context.Products.Where(p=>p.ProductID==productId).FirstOrDefault());
            _context.SaveChanges();
        }

        public Product Get(int productId)
        {
            return _context.Products.Where(p => p.ProductID == productId).FirstOrDefault();
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _context.Products.Where(p => p.ProductID == product.ProductID).FirstOrDefault();
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
           

            _context.SaveChanges();

        }
    }
}
