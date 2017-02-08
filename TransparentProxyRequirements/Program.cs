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
            // this is how to code works on Android/Console projects

            var observableType = typeof(Observable);

            // we look at the hidden field s_impl to get the existing implementation

            var field = observableType.GetField("s_impl", BindingFlags.Static | BindingFlags.NonPublic);
            var originalInterceptor = field.GetValue(null);

            // we create a transparent proxy for the original 
            var interceptor = new QueryLanguageProxy(originalInterceptor).GetTransparentProxy();

            // and assign the transparent proxy
            field.SetValue(null,interceptor);


            // 

        }
    }
}
