using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class RoleAuthorizeAttribute : ActionFilterAttribute
{
    private readonly string _role;

    public RoleAuthorizeAttribute(string role)
    {
        _role = role;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.User.IsInRole(_role))
        {
            context.Result = new RedirectToActionResult("AccessDenied", "Account", null);
        }
        base.OnActionExecuting(context);
    }
}