using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;

namespace OfflinePhotoOnly.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            return View(getPics());
        }

        public PartialViewResult Manifest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            return PartialView(getPics());
        }

        private List<string> getPics()
        {
            List<string> clientPaths = new List<string>();
            string path = Server.MapPath("/Content/Images");
            string[] filePaths = Directory.GetFiles(path);
            foreach (string file in filePaths)
            {
                FileInfo fi = new FileInfo(file);
                string fileName = fi.Name;
                clientPaths.Add("/Content/Images/" + fileName);
            }
            return clientPaths;
        }
    }
}