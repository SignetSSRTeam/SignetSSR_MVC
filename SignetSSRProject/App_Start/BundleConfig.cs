using System.Web;
using System.Web.Optimization;

namespace SignetSSRProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-carousel.css"));

            bundles.Add(new StyleBundle("~/bundles/jsgrid/CSS").Include(
                      "~/Content/JSGrid/jsgrid-theme.css",
                      "~/Content/JSGrid/jsgrid.css"));

            bundles.Add(new ScriptBundle("~/bundles/jsgrid").Include(
                      "~/Scripts/JSGrid/jsgrid.js",
                      "~/Scripts/JSGrid/validationhelper.js"));

            bundles.Add(new ScriptBundle("~/bundles/materials").Include(
                      "~/Scripts/Materials/materials.js"));

            bundles.Add(new ScriptBundle("~/bundles/hoursWorked").Include(
                      "~/Scripts/HoursWorked/hoursWorked.js"));

            bundles.Add(new ScriptBundle("~/bundles/modalform").Include(
                   "~/Scripts/modalform.js"));
 
        }
    }
}
