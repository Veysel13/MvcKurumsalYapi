using Northwind.Entities;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationService _authenticationManager;

        public AccountController(IAuthenticationService authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        // GET: Account
        public ActionResult Login()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Login(User user,string returnUrl)
        {
            if (ModelState.IsValid)
            {
               User validatedUser=_authenticationManager.Authenticate(user);
                if (validatedUser !=null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName,false);

                    return RedirectToAction(returnUrl);
                }
            }
            ModelState.AddModelError("hata","Kullanıcı veya şifre hatalı");
            return View(user);
        }
    }
}