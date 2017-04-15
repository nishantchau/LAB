using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LABURNUM.COM.Component;

namespace LABURNUM.COM.Controllers
{
    public class ClassWiseFacultiesController : MyBaseController
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();
        // GET: /ClassWiseFaculties/

        public ActionResult Index(string sid)
        {
            long logInBy = Convert.ToInt64(new Common().GetDecryptedId(sid));
            List<DTO.LABURNUM.COM.ClassSubjectFacultyTableModel> dbFaculties = new List<DTO.LABURNUM.COM.ClassSubjectFacultyTableModel>();
            DTO.LABURNUM.COM.ClassSubjectFacultyTableModel model = new DTO.LABURNUM.COM.ClassSubjectFacultyTableModel();
            if (logInBy == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PARENT))
            {
                model.ClassId = sessionManagement.GetClassId();
                model.SectionId = sessionManagement.GetSectionId();
                dbFaculties = new Component.ClassSubjectFacultyTable().GetClassSubjectFacultyByAdvanceSearch(model);
            }
            if (logInBy == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.FACULTY))
            {
                model.FacultyId = sessionManagement.GetFacultyId();
                dbFaculties = new Component.ClassSubjectFacultyTable().GetClassSubjectFacultyByAdvanceSearch(model);
            }
            return View(dbFaculties);
        }

    }
}
