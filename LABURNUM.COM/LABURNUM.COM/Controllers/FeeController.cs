using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class FeeController : MyBaseController
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();

        public ActionResult AddIndex()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
            {
                DTO.LABURNUM.COM.FeeModel model = new DTO.LABURNUM.COM.FeeModel();
                model.Classes = new LABURNUM.COM.Component.Class().GetActiveClasses();
                model.AdmissionTypes = new LABURNUM.COM.Component.AdmissionType().GetActiveAdmissionTypes();
                return View(model);
            }
            else
            {

                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }

        }

        public ActionResult AddFee(DTO.LABURNUM.COM.FeeModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Fee/Add", model).Result;
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

        public ActionResult EditFeeIndex(string id)
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
            {
                LABURNUM.COM.Component.Crypto crypto = new Component.Crypto();
                string text = crypto.DecryptStringAES(id, LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY);
                long feeid = Convert.ToInt64(text);
                DTO.LABURNUM.COM.FeeModel model = new LABURNUM.COM.Component.Fee().GetFeeById(feeid);
                //model.Classes = new LABURNUM.COM.Component.Class().GetActiveClasses();
                //model.AdmissionTypes = new LABURNUM.COM.Component.AdmissionType().GetActiveAdmissionTypes();
                return View(model);
            }
            else
            {

                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }

        }

        public ActionResult EditFee(DTO.LABURNUM.COM.FeeModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Fee/Update", model).Result;
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

        public ActionResult SeeAllFee()
        {
            if (sessionManagement.GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.ADMIN) || new LABURNUM.COM.Component.SessionManagement().GetLoginBy() == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PRINCIPLE))
            {
                List<DTO.LABURNUM.COM.FeeModel> dbFees = new LABURNUM.COM.Component.Fee().GetAllActiveFee();
                return View(dbFees);
            }
            else
            {

                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Dashboard/Index");
            }

        }

    }
}
