using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.Web;

namespace WinPhone7Authentication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HelloService" in code, svc and config file together.
    [AspNetCompatibilityRequirements(
       RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class HelloService : IHelloService
    {
        public string HelloWorld()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
                return HttpContext.Current.User.Identity.Name;
            else
                return "Unauthenticated Person";
        }
    }

    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        string HelloWorld();
    }
}
