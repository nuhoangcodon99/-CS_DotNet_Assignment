using System.Net;
using System.Text.Json;
using NWBC_Assignment05.Error;

namespace NWBC_Assignment05.Exception;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (CustomNotFoundException ex)
        {
            await HandleExceptionAsync(httpContext, ex, HttpStatusCode.NotFound);
        }
        catch (CustomBadRequestException ex)
        {
            await HandleExceptionAsync(httpContext, ex, HttpStatusCode.BadRequest);
        }
        catch (System.Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex, HttpStatusCode.InternalServerError);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, System.Exception exception, HttpStatusCode statusCode)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var error = new ApiError
        {
            ErrorCode = ((int)statusCode).ToString(),
            ErrorMessage = exception.Message
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(error));
    }
}
