using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VisaApplicationSystem.Services
{
    public class AuthorizeUser : Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string UserID = context.HttpContext.Session.GetString("UserID");
            if (string.IsNullOrEmpty(UserID))
            {
                context.HttpContext.Response.Redirect("/Account/Index");
            }
        }
    }
}
