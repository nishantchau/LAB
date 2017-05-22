using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class ListAllGalleryController : Controller
    {
        //
        // GET: /ListAllGallery/

        public ActionResult Index()
        {
            List<DTO.LABURNUM.COM.AlbumModel> dblist = new Component.Album().GetActiveAlbums();
            return View(dblist);
        }

        public ActionResult ViewByAlbumId(string id)
        {
            try
            {
                LABURNUM.COM.Component.Crypto crypto = new Component.Crypto();
                string text = crypto.DecryptStringAES(id, LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY);
                long cId = Convert.ToInt64(text);
                DTO.LABURNUM.COM.AlbumModel model = new LABURNUM.COM.Component.Album().GetAlbumByAlbumId(cId);
                return View(model);
            }
            catch (Exception ex)
            {
                return Redirect(LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Home/Index");
            }

        }
    }
}
