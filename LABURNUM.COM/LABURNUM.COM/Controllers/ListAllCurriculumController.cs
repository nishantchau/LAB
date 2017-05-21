using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class ListAllCurriculumController : Controller
    {
        //
        // GET: /ListAllCurriculum/

        public ActionResult Index()
        {
            List<DTO.LABURNUM.COM.CurriculumModel> model = new Component.Curriculum().GetCurriculumForSite();
            return View(model);
        }

    }
}
