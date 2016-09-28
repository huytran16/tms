using System.Web.Mvc;

namespace tms.Areas.HelpDesk
{
    public class HelpDeskAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HelpDesk";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "HelpDesk_default",
                "HelpDesk/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "tms.Areas.HelpDesk.Controllers" }
            );
        }
    }
}