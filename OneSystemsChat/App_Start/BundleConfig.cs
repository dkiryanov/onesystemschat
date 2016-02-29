using System.Web.Optimization;

namespace OneSystemsChat.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/Content/Scripts/global").Include("~/Scripts/global.js"));
            bundles.Add(new ScriptBundle("~/bundles/Content/Scripts/app/chat").Include("~/Scripts/App/ChatModel.js"));
            bundles.Add(new ScriptBundle("~/bundles/Content/Scripts/app/registration").Include("~/Scripts/App/User.Registration.js"));
            bundles.Add(new ScriptBundle("~/bundles/Content/Scripts/app/login").Include("~/Scripts/App/User.Login.js"));

            bundles.Add(new ScriptBundle("~/bundles/Content/Scripts/bootstrap").Include("~/Scripts/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/Content/Scripts/jquery").Include("~/Scripts/jquery-1.10.2.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/Content/Scripts/ko").Include("~/Scripts/knockout-3.4.0.js", "~/Scripts/knockout.validation.js"));
            bundles.Add(new ScriptBundle("~/bundles/Content/Scripts/modernizr").Include("~/Scripts/modernizr-2.8.3.js"));
            bundles.Add(new ScriptBundle("~/bundles/Content/Scripts/moment").Include("~/Scripts/moment.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/Content/Scripts/signalr").Include("~/Scripts/jquery.signalR-2.2.0.min.js"));

            bundles.Add(new StyleBundle("~/bindles/styles/bootstrap").Include("~/Content/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/bindles/styles/site").Include("~/Content/site.css"));
        }
    }
}