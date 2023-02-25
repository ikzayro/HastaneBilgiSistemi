using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneBilgiSistemi.Filter
{
    public class UserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? userId = context.HttpContext.Session.GetInt32("id");   //http istegindeki kullanıcı id'sini degişkene atıyoruz

            if (!userId.HasValue)   //id mevcut degil ise (yani kullanıcı giriş yapmamış ise)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary     //redirect route result oluşturup kullanıcı eger giriş yapmadan url çubugundan admin,lab,doktor veya hasta sayfalarına ulaşmak istiyor ise onu login sayfasına yönlendiriyoruz
                {
                    {"action", "Index" },
                    {"controller", "Home" }      
                }
                );
            }
            base.OnActionExecuting(context);    //oluşturdugumuz redirectrouteresult'ı uyguluyoruz
        }
        
    }
}
