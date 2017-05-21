using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class CurriculumController : MyBaseController
    {
        LABURNUM.COM.Component.SessionManagement sessionManagement = new Component.SessionManagement();
        // GET: /Curriculum/

        public ActionResult AddIndex()
        {
            DTO.LABURNUM.COM.CurriculumModel model = new DTO.LABURNUM.COM.CurriculumModel();
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN))
            {
                model.AcademicYears = new Component.AcademicYear().GetActiveAcademicYears();
            }
            model.Classes = new Component.Class().GetActiveClasses();
            model.Months = new Component.Month().GetActiveMonths();
            model.Subjects = new Component.Subject().GetActiveSubjectes();
            for (int i = 0; i < LABURNUM.COM.Component.Constants.DEFAULTVALUE.MAXCURRICULUMDETAILS; i++)
            {
                model.CurriculumDetails.Add(new DTO.LABURNUM.COM.CurriculumDetailModel());
            }

            return View(model);
        }

        public ActionResult Add(DTO.LABURNUM.COM.CurriculumModel model)
        {
            try
            {
                if (new Component.Curriculum().IsCurriculumPostForThisMonth(model.ClassId, model.MonthId.GetValueOrDefault()))
                {
                    return Json(new { code = -3, message = "failed" });
                }
                else
                {
                    if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN))
                    {
                    }
                    model.AcademicYearId = sessionManagement.GetAcademicYearTableId();
                    model.AddedById = sessionManagement.GetFacultyId();
                    model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                    HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("Curriculum", "Add", model);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        var id = Convert.ToInt16(data);
                        return Json(new { code = 0, message = "success" });
                    }
                    else
                    {
                        return Json(new { code = -1, message = "failed" });
                    }
                }
            }
            catch (Exception)
            {

                return Json(new { code = -2, message = "failed" });
            }
        }

        public ActionResult UpdateIndex(string id)
        {
            try
            {
                LABURNUM.COM.Component.Crypto crypto = new Component.Crypto();
                string text = crypto.DecryptStringAES(id, LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY);
                long cId = Convert.ToInt64(text);
                DTO.LABURNUM.COM.CurriculumModel model = new Component.Curriculum().GetCurriculumByCurriculumId(cId);
                model.Classes = new Component.Class().GetActiveClasses();
                model.Months = new Component.Month().GetActiveMonths();
                model.Subjects = new Component.Subject().GetActiveSubjectes();
                for (int i = model.CurriculumDetails.Count; i < LABURNUM.COM.Component.Constants.DEFAULTVALUE.MAXCURRICULUMDETAILS; i++)
                {
                    model.CurriculumDetails.Add(new DTO.LABURNUM.COM.CurriculumDetailModel());
                }
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Update(DTO.LABURNUM.COM.CurriculumModel model)
        {
            try
            {
                model.AcademicYearId = sessionManagement.GetAcademicYearTableId();
                model.AddedById = sessionManagement.GetFacultyId();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("Curriculum", "Update", model);
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { code = 0, message = "success" });
                }
                else
                {
                    return Json(new { code = -1, message = "failed" });
                }
            }
            catch (Exception)
            {

                return Json(new { code = -2, message = "failed" });
            }
        }

        public ActionResult SearchIndex()
        {
            DTO.LABURNUM.COM.CurriculumModel model = new DTO.LABURNUM.COM.CurriculumModel();
            model.Classes = new Component.Class().GetActiveClasses();
            model.Months = new Component.Month().GetActiveMonths();
            return View(model);
        }

        public ActionResult SearchCurriculum(DTO.LABURNUM.COM.CurriculumModel model)
        {
            try
            {
                List<DTO.LABURNUM.COM.CurriculumModel> dblist = new Component.Curriculum().GetCurriculumByAdvanceSearch(model);
                string html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Curriculum/SearchResult.cshtml", dblist);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                return Json(new { code = -1, message = "success", result = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Error404.cshtml", null) });
            }
        }
    }
}
