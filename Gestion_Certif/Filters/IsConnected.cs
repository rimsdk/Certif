using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gestion_Certif.Filters
{
    public class IsConnected : ActionFilterAttribute
    {
        public string? Role { get; set; }

        public override void
            OnActionExecuting(ActionExecutingContext context)
        {
          
            if (Role != null)
            {
                if (Role != context.HttpContext.Session.GetString("role"))
                {
                    context.Result = new
            RedirectResult("/Accueil/Page404");
                }
            }
        }
    }
}
