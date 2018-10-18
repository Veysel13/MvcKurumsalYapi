using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Entities;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bll.Concrete
{
    public class ProductManager : IProductService
    {
        private EfProductDal _productDal;

        public ProductManager(EfProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
           _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(productId);
        }

        public Product Get(int productId)
        {
            return _productDal.Get(productId);
        }

        public List<Product> GetAll()
        {
          return  _productDal.GetAll();
        }

        public void Update(Product product)
        {
           _productDal.Update(product);
        }
    }
}
