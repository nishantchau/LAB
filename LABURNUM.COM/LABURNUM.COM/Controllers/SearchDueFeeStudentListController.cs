using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class SearchDueFeeStudentListController : Controller
    {
        //
        // GET: /SearchDueFeeStudentList/

        public ActionResult Index()
        {
            DTO.LABURNUM.COM.StudentFeeModel model = new DTO.LABURNUM.COM.StudentFeeModel();
            model.Classes = new Component.Class().GetActiveClasses();
            model.Sections = new Component.Section().GetActiveSections();
            return View(model);
        }

        public ActionResult SearchDueFeeList(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            try
            {
                model.ApiClientModel = new Component.Common().GetApiClientModel();
                HttpResponseMessage response = new Component.Common().GetHTTPResponse("", "", model);
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { code = 1, message = "success" });
                }
                else
                {
                    return Json(new { code = -2, message = "failed" });
                }
            }
            catch (Exception)
            {

                return Json(new { code = -3, message = "failed" });
            }
        }
    }
}
