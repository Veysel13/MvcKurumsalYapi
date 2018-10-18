using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Northwind.Entities;
using Northwind.MvcWebUI.Infrastructure;
using Northwind.MvcWebUI.ModelBinders;

namespace Northwind.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //controllerı nı nınjectfactory ile cozumle
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            //eger biri senden Cart nesnesını ısterse ona cartmodelbinder ı ver
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(Cart),new CartModelBinder());
        }
    }
}
