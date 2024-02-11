using EntityLayer.Enum;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExaminationSystem.LoginControl
{
    public class AdminLoginControl : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var roleId = context.HttpContext.Session.GetInt32("roleId");
            if (roleId == (int)RoleType.Admin)
            {
                var result = await next();
            }
            else
            {
                context.HttpContext.Response.Redirect("/Login/Index");
            }
        }
    }
}
