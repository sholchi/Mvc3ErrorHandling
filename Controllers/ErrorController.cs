using System.Web.Mvc;
using Elmah;
using ElmahAndMvc3.ErrorHandler.Exceptions;

namespace ElmahAndMvc3.Controllers
{
    public class ErrorController : Controller
    {
        public void LogJavaScriptError(string message)
        {
            ErrorSignal.FromCurrentContext().Raise(new JavaScriptException(message));
        }
    }
}
