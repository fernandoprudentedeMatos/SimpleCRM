using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using SimpleCRM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCRM.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            string message = "ops, erro crítico ocorreu. :(";
            context.HttpContext.Response.StatusCode = 500;

            if (context.Exception is InvalidServiceRequestException)
            {
                message = context.Exception.Message;
                context.HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
            }
            else
            {
                //TODO: Logger
                //-- LOGGER
            }

            context.Exception = null;

            context.HttpContext.Response.WriteAsync(message);

            base.OnException(context);
        }
    }
}
