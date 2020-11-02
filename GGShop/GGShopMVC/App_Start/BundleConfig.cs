using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace GGShopMVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundle)
        {
            bundle.Add(new ScriptBundle("~/bundles/scripts").Include("~/Scripts/scripts.js", "~/Scripts/jquery.waypoints.js", "~/Scripts/jquery-3.4.1.js"));
            bundle.Add(new StyleBundle("~/Content/themes/base/css").Include("~/Content/themes/base/*.css"));
        }
    }
}