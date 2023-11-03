using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Berger.Extensions.Jwt
{
    public class SecurityActionFilter : ActionFilterAttribute
    {
        #region Constructors
        public SecurityActionFilter()
        {
        }
        #endregion

        #region Events
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _ = context.Controller as Controller;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }
        #endregion
    }
}