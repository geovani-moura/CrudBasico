using System.Web;
using System.Web.Optimization;

namespace CrudBasico
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/template/css").Include(
					  "~/template/vendor/bootstrap/css/bootstrap.min.css",
					  "~/template/vendor/bootstrap-icons/bootstrap-icons.css",
					  "~/template/vendor/boxicons/css/boxicons.min.css",
					  "~/template/vendor/quill/quill.snow.css",
					  "~/template/vendor/quill/quill.bubble.css",
					  "~/template/vendor/remixicon/remixicon.css",
					  "~/node_modules/datatables.net-bs5/css/dataTables.bootstrap5.min.css",
					  "~/template/css/style.css",
					  "~/Content/Site.css"
			));

			bundles.Add(new Bundle("~/template/js").Include(
					  "~/node_modules/jquery/dist/jquery.min.js",
					  "~/template/vendor/apexcharts/apexcharts.min.js",
					  "~/template/vendor/bootstrap/js/bootstrap.bundle.mim.js",
					  "~/template/vendor/chart.js/chart.umd.js",
					  "~/template/vendor/echarts/echarts.min.js",
					  "~/template/vendor/quill/quill.min.js",
					  "~/template/vendor/tinymce/tinymce.min.js",
					  "~/template/vendor/php-email-form/validate.js",
					  "~/node_modules/datatables.net/js/dataTables.min.js",
					  "~/node_modules/datatables.net-bs5/js/dataTables.bootstrap5.min.js",
					  "~/template/js/main.js",
					  "~/Scripts/Site.js"
			));
		}
	}
}
