using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;


namespace BaseHomeWork.Filters
{
    public class SetUserNameAttribute: Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string userName;
            if (!context.HttpContext.Request.Cookies.TryGetValue("User", out userName)) userName = "Guest";
            context.HttpContext.Session.SetString("user_name", userName);
        }        
    }
}
