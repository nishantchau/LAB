using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class ContactUsController : Controller
    {
        //
        // GET: /ContactUs/

        public ActionResult Index()
        {
            DTO.LABURNUM.COM.MailerModel model = new DTO.LABURNUM.COM.MailerModel();
            return View(model);
        }

        public ActionResult SendMail(DTO.LABURNUM.COM.MailerModel model)
        {
            try
            {
                if (new Component.Mailer().sendMail(model)) { return Json(new { code = 0, message = "success" }); }
                else { return Json(new { code = -1, message = "failed" }); }
            }
            catch (Exception)
            {
                return Json(new { code = -2, message = "failed" });
            }
        }
    }
}
