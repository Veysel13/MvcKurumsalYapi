using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Interception;

namespace Northwind.CrossCuttingConcerns.Logging
{

    //nuget paketden ninject i kuruyoruz
    //nuget den ninject extension interception paketını de kuruyoruz loglama için gerekli alt yapı
   public class LoggingInterceptor:SimpleInterceptor
    {
        //metoddan once calsıacak
        protected override void BeforeInvoke(IInvocation invocation)
        {
            //loglama fremaworkuun loglama ıslemlerı yapılacak


            //invocation.Request.Method.Name
            base.BeforeInvoke(invocation);
        }

        //metotdan sonra calısacak
        protected override void AfterInvoke(IInvocation invocation)
        {
            base.AfterInvoke(invocation);
        }
    }
}
