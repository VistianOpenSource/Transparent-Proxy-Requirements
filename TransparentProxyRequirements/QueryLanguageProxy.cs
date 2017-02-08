using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace TransparentProxyRequirements
{
    public class QueryLanguageProxy:RealProxy, IRemotingTypeInfo
    {
        private readonly object _originalInterceptor;

        public QueryLanguageProxy(object originalInterceptor): base(typeof(ContextBoundObject))
        {
            _originalInterceptor = originalInterceptor;
        }

        public override IMessage Invoke(IMessage msg)
        {
            // this is where we would log what happens
            // and also invoke the actual message

            throw new NotImplementedException();
        }


        public bool CanCastTo(Type fromType, object o)
        {
            return fromType.Name == "IQueryLanguage";
        }

        public string TypeName
        {
            get { return this.GetType().Name; } set { }
        }
    }
}
