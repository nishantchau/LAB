using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace LABURNUM.COM.Controllers
{
    public class ProspectusController : Controller
    {


        public FileStreamResult pdf()
        {
            MemoryStream workStream = new MemoryStream();
            Document document = new Document();
            PdfWriter.GetInstance(document, workStream).CloseStream = false;

            document.Open();
            document.Add(new Paragraph("Hello World"));
            document.Add(new Paragraph(DateTime.Now.ToString()));
            document.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return new FileStreamResult(workStream, "application/pdf");
        }


        // GET: /Prospectus/
        public ActionResult Index()
        {
            return View();
        }

        //public FileContentResult ViewPDF()
        //{
        //    //string path = LABURNUM.COM.Component.Constants.URL.WEBSITEURL + "Uploads/Prospectus/PROSPECTUS.pdf";
        //    //FileStream fs = new FileStream("E:\\Projects\Working Projects\SHARED PROJECT\LAB\LABURNUM.COM\LABURNUM.COM\Uploads\Prospectus", FileMode.Open, FileAccess.Read);
        //    //return File(fs, "application/pdf");

        //    var fullPathToFile = @"http://www.laburnumpublicschool.com/Uploads/Prospectus/PROSPECTUS.pdf";
        //    var mimeType = "application/pdf";
        //    var fileContents = System.IO.File.ReadAllBytes(fullPathToFile);
        //    return new FileContentResult(fileContents, mimeType);

        //}
    }
}
