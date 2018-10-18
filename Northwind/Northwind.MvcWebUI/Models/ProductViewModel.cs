using System.Collections.Generic;
using Northwind.Entities;

namespace Northwind.MvcWebUI.Models
{
    public class ProductViewModel
    {
        public List<Product> Prodcuts { get; set; }
        public object PageingInfo { get; set; }
    }
}