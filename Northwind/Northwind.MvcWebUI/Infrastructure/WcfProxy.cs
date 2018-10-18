using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Northwind.Interfaces;

namespace Northwind.MvcWebUI.Infrastructure
{
    public static class WcfProxy<T>
    {
        public static T CreateChannel()
        {
            //subsstrıng ile basdakı I yı dusurdum
            string address =String.Format("http://localhost:53945/{0}.svc?wsd1", typeof(T).Name.Substring(1));
            var binding = new BasicHttpBinding();
            var channel=new ChannelFactory<T>(binding,address);

            return channel.CreateChannel();
        }
    }
}