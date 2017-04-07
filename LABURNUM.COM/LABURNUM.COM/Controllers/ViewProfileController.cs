using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class ViewProfileController : MyBaseController
    {

        // GET: /ViewProfile/

        public ActionResult Index(string id)
        {
            try
            {
                string text = new Component.Crypto().DecryptStringAES(id, LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY);
                long userid = Convert.ToInt64(text);
                long loginby = new Component.SessionManagement().GetLoginBy();
                DTO.LABURNUM.COM.SessionModel model = new DTO.LABURNUM.COM.SessionModel() { LoginBy = loginby };
                if (loginby == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.STUDENT) || loginby == DTO.LABURNUM.COM.Utility.UserType.GetValue(DTO.LABURNUM.COM.Utility.EnumUserType.PARENT))
                {
                    model.StudentModel = new Component.Student().GetStudentByStudentId(userid);
                }
                else
                {
                    model.FacultyModel = new Component.Faculty().GetFacultyById(userid);
                }
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
