using System.Web;
using System.Web.Optimization;

namespace TheNight_JustBuy
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/asset/scripts/datatable").Include(
                        "~/Asset/plugins/datatables/jquery.dataTables.min.js",
                        "~/Asset/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js",
                        "~/Asset/plugins/datatables-responsive/js/dataTables.responsive.min.js",
                        "~/Asset/plugins/datatables-responsive/js/responsive.bootstrap4.min.js",
                        "~/Content/DataTables/Buttons-1.6.5/js/dataTables.buttons.min.js",
                        "~/Content/DataTables/Buttons-1.6.5/js/buttons.flash.min.js",
                        "~/Content/DataTables/pdfmake-0.1.36/pdfmake.min.js",
                        "~/Content/DataTables/JSZip-2.5.0/jszip.min.js",
                        "~/Content/DataTables/Buttons-1.6.5/js/buttons.print.min.js",
                        "~/Content/DataTables/Buttons-1.6.5/js/buttons.html5.min.js",
                        "~/Content/DataTables/pdfmake-0.1.36/vfs_fonts.js",
                        "~/Content/jsControllers/jsDatatable.js"));

            bundles.Add(new ScriptBundle("~/asset/scripts/form").Include(
                        "~/Asset/plugins/daterangepicker/daterangepicker.js",
                        "~/Asset/plugins/bs-custom-file-input/bs-custom-file-input.min.js",
                        "~/Asset/plugins/summernote/summernote-bs4.min.js"));

            bundles.Add(new ScriptBundle("~/asset/scripts/select2").Include(
                        "~/Asset/plugins/select2/js/select2.full.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/asset/css/datatable").Include(
                      "~/Asset/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css",
                      "~/Asset/plugins/datatables-responsive/css/responsive.bootstrap4.min.css"));

            bundles.Add(new StyleBundle("~/asset/css/form").Include(
                      "~/Asset/plugins/daterangepicker/daterangepicker.css",
                      "~/Asset/plugins/summernote/summernote-bs4.min.css"));

            bundles.Add(new StyleBundle("~/asset/css/select2").Include(
                      "~/Asset/plugins/select2/css/select2.min.css"));
        }
    }
}
