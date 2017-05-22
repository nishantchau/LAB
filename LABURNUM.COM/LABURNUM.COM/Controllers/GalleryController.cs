using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class GalleryController : Controller
    {
        Component.SessionManagement sessionManagement = new Component.SessionManagement();
        // GET: /Gallery/

        public ActionResult AddIndex()
        {
            DTO.LABURNUM.COM.AlbumModel model = new DTO.LABURNUM.COM.AlbumModel();
            for (int i = 0; i < Component.Constants.DEFAULTVALUE.MAXPHOTOINONEALBUM; i++)
            {
                model.AlbumDetails.Add(new DTO.LABURNUM.COM.AlbumDetailModel());
            }
            return View(model);
        }

        public ActionResult Add(DTO.LABURNUM.COM.AlbumModel model)
        {
            try
            {
                model.AddedById = sessionManagement.GetFacultyId();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("Album", "Add", model);
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
                DTO.LABURNUM.COM.AlbumModel model = new Component.Album().GetAlbumByAlbumId(cId);
                for (int i = model.AlbumDetails.Count; i < @Component.Constants.DEFAULTVALUE.MAXPHOTOINONEALBUM; i++)
                {
                    model.AlbumDetails.Add(new DTO.LABURNUM.COM.AlbumDetailModel());
                }
                return View(model);
            }
            catch (Exception)
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Error404/Index");
            }
        }

        public ActionResult Update(DTO.LABURNUM.COM.AlbumModel model)
        {
            try
            {
                model.UpdatedById = sessionManagement.GetFacultyId();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpResponseMessage response = new LABURNUM.COM.Component.Common().GetHTTPResponse("Album", "Update", model);
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
            DTO.LABURNUM.COM.AlbumModel model = new DTO.LABURNUM.COM.AlbumModel();
            return View(model);
        }

        public ActionResult SearchGallery(DTO.LABURNUM.COM.AlbumModel model)
        {
            try
            {
                List<DTO.LABURNUM.COM.AlbumModel> dblist = new Component.Album().GetAlbumByAdvanceSearch(model);
                string html = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Gallery/SearchResult.cshtml", dblist);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                return Json(new { code = -1, message = "success", result = new Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Error404.cshtml", null) });
            }
        }

    }
}
