using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Optimization;

namespace SSDonationPresentationLayer
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var bundle = new ScriptBundle("~/bundles/jquery").Include(
                 "~/Scripts/jquery-{version}.min.js").Include(
                  "~/Scripts/eWay.min.js").Include(
                "~/Scripts/modernizr-*").Include(
                 "~/Scripts/app.js").Include(
                        "~/Scripts/jquery.validate*");
            bundle.Orderer = new BundleOrderer();
            bundles.Add(bundle);
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
    class BundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}
