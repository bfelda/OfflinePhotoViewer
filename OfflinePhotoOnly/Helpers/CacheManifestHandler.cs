using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.IO;


namespace OfflinePhotoOnly.Helpers
{
    public class CacheManifestHandler:IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.Cache.SetNoStore();
            context.Response.Cache.SetExpires(DateTime.MinValue);
            context.Response.ContentType = "text/cache-manifest";
            context.Response.Write("CACHE MANIFEST" + Environment.NewLine);
            context.Response.Write("CACHE:" + Environment.NewLine);
            foreach (string imagePath in getPics())
            {
                context.Response.Write(Scripts.Url(imagePath) + Environment.NewLine);
            }
        }

        private List<string> getPics()
        {
            List<string> clientPaths = new List<string>();
            string path = @"C:\Users\Ben\Dropbox\Projects\OfflinePhotoOnly\OfflinePhotoOnly\Content\Images";
            string[] filePaths = Directory.GetFiles(path);
            foreach (string file in filePaths)
            {
                FileInfo fi = new FileInfo(file);
                string fileName = fi.Name;
                clientPaths.Add("/Content/Images/" + fileName);
            }
            return clientPaths;
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}