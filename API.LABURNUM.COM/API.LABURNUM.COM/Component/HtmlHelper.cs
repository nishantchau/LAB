using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace API.LABURNUM.COM.Component
{
    public class HtmlHelper
    {
        /// <summary>
        /// Convert The View In A String 
        /// </summary>
        /// <param name="controllerName"></param>
        /// <param name="viewName"></param>
        /// <param name="viewData"></param>
        /// <returns>View In Single String</returns>
        public string RenderViewToString(string controllerName, string viewName, object viewData)
        {
            using (var writer = new StringWriter())
            {
                var routeData = new RouteData();
                routeData.Values.Add("controller", controllerName);
                var fakeControllerContext = new ControllerContext(new HttpContextWrapper(new HttpContext(new HttpRequest(null, "http://google.com", null), new HttpResponse(null))), routeData, new FakeController());
                var razorViewEngine = new RazorViewEngine();
                var razorViewResult = razorViewEngine.FindView(fakeControllerContext, viewName, "", false);

                var viewContext = new ViewContext(fakeControllerContext, razorViewResult.View, new ViewDataDictionary(viewData), new TempDataDictionary(), writer);
                razorViewResult.View.Render(viewContext, writer);
                string body = writer.ToString();
                return body;
            }
        }

        public class FakeController : ControllerBase { protected override void ExecuteCore() { } }
    }
}