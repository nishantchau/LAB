using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class CommonController : MyBaseController
    {
        public ActionResult SectionByClassId(long classId)
        {
            try
            {
                return Json(new { code = 0, sections = new LABURNUM.COM.Component.Section().GetSectionByClassId(classId) });
            }
            catch (Exception)
            {
                return Json(new { code = -1, sections = string.Empty });

            }
        }

        [HttpPost]
        public ContentResult UploadFiles(string name)
        {
            try
            {
                var r = new List<DTO.LABURNUM.COM.UploadFilesModel>();
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                    if (hpf.ContentLength == 0)
                        continue;
                    string path = "~/Uploads/ProfileImages";
                    bool folderExists = Directory.Exists(Server.MapPath(path));
                    if (!folderExists)
                        Directory.CreateDirectory(Server.MapPath(path));
                    string extension = Path.GetExtension(hpf.FileName);
                    string savedFileName = Path.Combine(Server.MapPath(path), Path.GetFileName(name + extension));
                    if (savedFileName.EndsWith(".jpg") || savedFileName.EndsWith(".bmp") || savedFileName.EndsWith(".png"))
                    {
                        hpf.SaveAs(savedFileName);
                        r.Add(new DTO.LABURNUM.COM.UploadFilesModel()
                        {
                            Name = name + extension
                        });
                    }
                    else
                    {
                        return Content("{\"error\":\"" + "Please Choose Picture File" + "\" }", "application/json");
                    }
                }
                return Content("{\"name\":\"" + r[0].Name + "\" }", "application/json");
            }
            catch (Exception ex)
            {
                return Content("{\"name\":\"" + "Something Goes Wrong.Please Try Again" + "\" }", "application/json");
            }
        }

        [HttpPost]
        public ContentResult UploadCircularFiles()
        {
            try
            {
                string name = Guid.NewGuid().ToString();
                var r = new List<DTO.LABURNUM.COM.UploadFilesModel>();
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                    if (hpf.ContentLength == 0)
                        continue;
                    string path = "~/Uploads/Circulars/";
                    bool folderExists = Directory.Exists(Server.MapPath(path));
                    if (!folderExists)
                        Directory.CreateDirectory(Server.MapPath(path));
                    string extension = Path.GetExtension(hpf.FileName);
                    string savedFileName = Path.Combine(Server.MapPath(path), Path.GetFileName(name + extension));
                    if (savedFileName.EndsWith(".pdf") || savedFileName.EndsWith(".doc") || savedFileName.EndsWith(".docx") || savedFileName.EndsWith(".jpg") || savedFileName.EndsWith(".bmp") || savedFileName.EndsWith(".png"))
                    {
                        hpf.SaveAs(savedFileName);
                        r.Add(new DTO.LABURNUM.COM.UploadFilesModel()
                        {
                            Name = name + extension
                        });
                    }
                    else
                    {
                        return Content("{\"error\":\"" + "Please Choose A File Of Type .pdf, .doc, .docx, .jpg, .bmp, .png" + "\" }", "application/json");
                    }
                }
                return Content("{\"name\":\"" + r[0].Name + "\" }", "application/json");
            }
            catch (Exception ex)
            {
                return Content("{\"name\":\"" + "Something Goes Wrong.Please Try Again" + "\" }", "application/json");
            }
        }

        public ActionResult EncrptId(string id)
        {
            try
            {
                return Json(new { id = new LABURNUM.COM.Component.Crypto().EncryptStringAES(id, LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY), message = "y" });
            }
            catch (Exception ex)
            {
                return Json(new { id = string.Empty, message = "n" });
            }
        }

        public ActionResult SearchTransportCharge(long id)
        {
            try
            {
                return Json(new { TransportCharge = new LABURNUM.COM.Component.BusRoute().GetBusRouteByRouteId(id).TranportCharges, message = "y" });
            }
            catch (Exception)
            {
                return Json(new { TransportCharge = 0, message = "n" });
            }
        }
    }
}
