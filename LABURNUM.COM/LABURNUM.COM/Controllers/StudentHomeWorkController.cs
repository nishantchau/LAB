using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class StudentHomeWorkController : MyBaseController
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();
        // GET: /StudentHomeWork/

        public ActionResult TodayHomeWorkIndex()
        {
            DTO.LABURNUM.COM.HomeWorkModel model = new DTO.LABURNUM.COM.HomeWorkModel();
            model.ClassId = sessionManagement.GetClassId();
            model.SectionId = sessionManagement.GetSectionId();
            model.StartDate = System.DateTime.Now;
            List<DTO.LABURNUM.COM.HomeWorkModel> dbHomeWorks = new Component.HomeWork().GetHomeWorkByAdvanceSearch(model);
            return View(dbHomeWorks);
        }

        public ActionResult SearchHomeWorkIndex()
        {
            DTO.LABURNUM.COM.HomeWorkModel model = new DTO.LABURNUM.COM.HomeWorkModel();
            model.Subjects = new Component.Subject().GetActiveSubjectes();
            return View(model);
        }

        public ActionResult SearchHomeWork(DTO.LABURNUM.COM.HomeWorkModel model)
        {
            try
            {
                model.ClassId = sessionManagement.GetClassId();
                model.SectionId = sessionManagement.GetSectionId();
                List<DTO.LABURNUM.COM.HomeWorkModel> dbHomeWorks = new Component.HomeWork().GetHomeWorkByAdvanceSearch(model);
                string html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/StudentHomeWork/StudentSearchHomeWorkResult.cshtml", dbHomeWorks);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception ex)
            {
                return Json(new { code = -1, message = "failed" });
            }

        }
    }
}
