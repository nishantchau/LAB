using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class DashboardController : MyBaseController
    {
        //
        // GET: /Dashboard/

        public ActionResult Index()
        {
            DTO.LABURNUM.COM.DashBoardModel model = new DTO.LABURNUM.COM.DashBoardModel();
            model.SMSBalance = new Component.SMSAPI().GetSMSBalance();
            return View(model);
        }

    }
}
