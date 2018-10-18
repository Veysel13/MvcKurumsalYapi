using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Northwind.Bll.Concrete;
using Northwind.CrossCuttingConcerns.Logging;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Interfaces;

namespace Northwind.MvcWebUI.Infrastructure
{
    //nuget paketden ninject i kuruyoruz
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        //ninject nugetten kurulur

        private IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel=new StandardKernel();
            //controller uzerınden calısması ıcın
            AddBllBindings();

            //Service Üzerinden Çalısması İçin
            //AddServiceBindings();

        }

        //controlarda verinin ne dondugnnu anlamak için
        private void AddBllBindings()
        {
            _ninjectKernel.Bind<IProductService>().To<ProductManager>().WithConstructorArgument("productDal",new EfProductDal());
            _ninjectKernel.Bind<ICategoryService>().To<CategoryManager>().WithConstructorArgument("categoryDal", new EfCategoryDal());
            _ninjectKernel.Bind<IAuthenticationService>().To<AuthanticationManager>().WithConstructorArgument("authenticationDal", new EfAuthenticationDal());

            //loglama uygulamak ıcın
            //nuget oaketden extension interceptionu eklıyoruz
            //tum actionlara log lama uygula
            _ninjectKernel.Intercept(p=>(true)).With(new LoggingInterceptor());
        }

        //service sistemini ayaga kladırmak için
        private void AddServiceBindings()
        {
            _ninjectKernel.Bind<IProductService>().ToConstant(WcfProxy<IProductService>.CreateChannel());
            _ninjectKernel.Bind<ICategoryService>().ToConstant(WcfProxy<ICategoryService>.CreateChannel());
            _ninjectKernel.Bind<IAuthenticationService>().ToConstant(WcfProxy<IAuthenticationService>.CreateChannel());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null :(IController)_ninjectKernel.Get(controllerType);
        }
    }
}