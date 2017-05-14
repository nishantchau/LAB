using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class SearchFeeReceiptController : Controller
    {
        //
        // GET: /SearchFeeReceipt/

        public ActionResult Index()
        {
            DTO.LABURNUM.COM.StudentFeeDetailModel model = new DTO.LABURNUM.COM.StudentFeeDetailModel();
            return View(model);
        }

        public ActionResult SearchResult(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            string html = string.Empty;
            try
            {
                List<DTO.LABURNUM.COM.StudentFeeDetailModel> dblist = new Component.StudentFeeDetails().GetStudentFeeDetailByAdvanceSearch(model);
                html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/SearchFeeReceipt/SearchResult.cshtml", dblist);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/_ViewStart.cshtml", null);
                return Json(new { code = -2, message = "failed", result = html });
            }
        }
    }
}
