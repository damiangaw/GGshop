using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GGShopMVC.AccessLayer
{
    public class AppConfig
    {
        private static string _imageFolderRelative = ConfigurationManager.AppSettings["ImageFolder"];

        public static string ImageFolderRelative
        {
            get
            { 
                return _imageFolderRelative; //Helper i skrót do folderu z zdjęciami.
            }
        }
    }
}