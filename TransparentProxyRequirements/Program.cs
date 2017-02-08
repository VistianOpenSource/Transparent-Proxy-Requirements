using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reflection;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace TransparentProxyRequirements
{
    class Program
    {
        static void Main(string[] args)
        {
            // this is how the code works on Android/Console projects

            //ensure reactive extensions is loaded.
            var observableType = typeof(Observable);

            // we look at the hidden field s_impl to get the existing implementation for the query language interface
            var field = observableType.GetField("s_impl", BindingFlags.Static | BindingFlags.NonPublic);
            var originalInterceptor = field.GetValue(null);

            // we create a transparent proxy for the original query language implementation
            var interceptor = new QueryLanguageProxy(originalInterceptor).GetTransparentProxy();

            // and assign the transparent proxy
            field.SetValue(null,interceptor);

            // now, all operations run through our transparent proxy.
        }
    }
}
