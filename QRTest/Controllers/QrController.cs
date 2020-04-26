using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRCoder;

namespace QRTest.Controllers
{
    public class QrController : Controller
    {
        // GET: Qr
        public ActionResult Index()
        {
            GenerateQr();
            return View();
        }

        private void GenerateQr(string customQr = "")
        {
            ViewBag.QrData = customQr == "" ? Guid.NewGuid().ToString() : customQr;
            string fileName = Guid.NewGuid().ToString() + ".jpg";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(ViewBag.QrData, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            var folder = "Qrs\\";
            var path = Server.MapPath("~") + folder;
            qrCodeImage.Save(path + fileName, ImageFormat.Jpeg );
            ViewBag.QrFile = fileName;
        }
        
        [HttpGet]
        public ActionResult CustomQr()
        {
            //[...] retrive your record object
            @ViewBag.QrData = "www.Example.com";
            GenerateQr(@ViewBag.QrData);
            return View();
        }

        [HttpPost]
        public ActionResult CustomQr(string customQrData = "Custom.Qr.Data")
        {
            @ViewBag.QrData = customQrData;
            GenerateQr(customQrData);
            return View();
        }
    }
}