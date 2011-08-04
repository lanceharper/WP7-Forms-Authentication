using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.ServiceModel.Activation;

namespace MvcApplication1
{
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
}