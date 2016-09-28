using System.Web.Mvc;

namespace tms.Areas.Technician
{
    public class TechnicianAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Technician";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Technician_default",
                "Technician/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "tms.Areas.Technician.Controllers" }
            );
        }
    }
}