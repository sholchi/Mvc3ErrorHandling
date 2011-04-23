using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Elmah;
using ElmahAndMvc3.ErrorHandler.Attributes;

namespace ElmahAndMvc3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ElmahHandleErrorAttribute());
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        public void ErrorMail_Filtering(object sender, ExceptionFilterEventArgs e)
        {
            var httpException = e.Exception as HttpException;
            if (httpException != null && httpException.GetHttpCode() == 404)
            {
                e.Dismiss();
            }

            #if DEBUG
                e.Dismiss();
            #endif
        }    
    }
}