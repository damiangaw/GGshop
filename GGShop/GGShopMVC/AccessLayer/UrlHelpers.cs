using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GGShopMVC.AccessLayer
{
    public static class UrlHelpers
    {
        public static string ImageFolderPath(this UrlHelper helper, string CoverFileName)
        {
            var imageFolder = AppConfig.ImageFolderRelative;
            var path = Path.Combine(imageFolder, CoverFileName);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }
    }
}