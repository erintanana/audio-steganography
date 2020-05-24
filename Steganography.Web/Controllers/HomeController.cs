using Steganography.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Steganography.Web.Controllers
{
    public class HomeController : Controller
    {
        [RequireHttps]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload, EmbedModel embed)
        {
            if (upload != null)
            {
                string fileName = System.IO.Path.GetFileName(upload.FileName);
            }

            byte[] byteArray = new byte[upload.ContentLength];
            upload.InputStream.Read(byteArray, 0, upload.ContentLength);
            short[] shortArray = new short[(int)Math.Ceiling((decimal)byteArray.Length) / 2];
            int shortSize = shortArray.Length;
            Buffer.BlockCopy(byteArray, 0, shortArray, 0, byteArray.Length);
            short[] metadata = new short[22];
            Buffer.BlockCopy(shortArray, 0, metadata, 0, metadata.Length * 2);
            int wavDataSize = shortArray.Length - metadata.Length;
            short[] wavdata = new short[wavDataSize];
            Buffer.BlockCopy(shortArray, metadata.Length * 2, wavdata, 0, wavdata.Length * 2);

            AudioModel model = new AudioModel
            {
                ByteArray = byteArray,
                ShortStream = shortArray,
                MetaData = metadata,
                Wavdata = wavdata,
                WavSize = wavDataSize,
                ShortSize = shortSize
            };



            return View("ResultView", model);
        }

        public ActionResult GetStarted()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Message = "Let's start embedding your message!";
            return View();
        }

    }
}