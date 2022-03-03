using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using properties.core.exceptions;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace properties.infraestructure.filtres
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        void IExceptionFilter.OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(ExceptionsBusiness))
            {
                var Exception = (ExceptionsBusiness)context.Exception;
                var validation = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = Exception.Message
                };

                var json = new
                {
                    errors = new[] { validation }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}
