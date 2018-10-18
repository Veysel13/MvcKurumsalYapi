using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Entities;
using Northwind.Interfaces;
using Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        //ProductManager _productManager=new ProductManager(new EfProductDal());

        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public int PageSize = 5;

        //cateogryideki urunleri getirmek için 
        public ActionResult Index(int page=1,int category=0)
        {
            //yaprıgımız sorguda category 0 sa herhangi bir filtreleme yapılmaz tum urunler gelir
            List<Product> products = _productService.GetAll().Where(p=>p.CategoryID==category || category==0).ToList();

            return View(new ProductViewModel
            {
                Prodcuts=products.Skip((page - 1) * PageSize).Take(PageSize).ToList(),
                PageingInfo=new PageingInfo
                {
                    ItemsPerPage=PageSize,
                    TotalItems=products.Count,
                    CurrentPage=page,
                    CurrentCategory=category
                }

            });
        }
    }

    
}