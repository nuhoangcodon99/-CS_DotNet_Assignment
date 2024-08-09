using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NWBC_Assignment04.Error;

namespace NWBC_Assignment04.Exception;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var error = new ApiError
        {
            ErrorCode = "400",
            ErrorMessage = context.Exception.Message
        };

        context.Result = new JsonResult(error)
        {
            StatusCode = (int)HttpStatusCode.BadRequest
        };
        context.ExceptionHandled = true;
    }
}
