using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.Entities;
using Northwind.Interfaces;

namespace Northwind.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }


        //[HttpPost]
        //public RedirectToRouteResult AddToCart(int productId)
        //{

        //    Product product = _productService.Get(productId);

        //    var cart = (Cart)Session["cart"];
        //    if (cart==null)
        //    {
        //        cart=new Cart();
        //        Session["cart"] = cart;
        //    }
        //    cart.AddToCart(product, 1);


        //    return RedirectToAction("Index",cart);
        //}

        [HttpPost]
        public RedirectToRouteResult AddToCart(Cart cart,int productId)
        {

            Product product = _productService.Get(productId);
            cart.AddToCart(product, 1);
            return RedirectToAction("Index", cart);
        }

        //public ActionResult Index()
        //{
        //    var cart = (Cart) Session["cart"];
        //    return View(cart);
        //}

        public ActionResult Index(Cart cart)
        {
           
            return View(cart);
        }

        [HttpPost]
        public RedirectToRouteResult RemoveFromCart(Cart cart,int productId)
        {
            Product prodcut = _productService.Get(productId);

                cart.RemoveFromCart(prodcut);

            return RedirectToAction("Index", cart);


        }

        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails shippingDetails)
        {
            //veriler dogru şekilde girilmisse
            if (ModelState.IsValid)
            {

                return  View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
            
        }

        //public PartialViewResult CartSummary()
        //{
        //    var cart = (Cart) Session["cart"];
        //    if (cart==null)
        //    {
        //        cart=new Cart();
        //    }
        //    return PartialView(cart);
        //}

        //modelbinder ile bu metodu bagladık
        public PartialViewResult CartSummary(Cart cart)
        {
           
            return PartialView(cart);
        }
    }

    
}

