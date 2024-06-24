using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Text.Json;

namespace exception_filters.Controllers
{
    // There are Several ways to Handle Exceptions in ASP.Net Core 6 Web API
    // 1. USING MIDDLEWARE FOR GLOBAL EXCEPTION HANDLING
    // 2. USING `EXCEPTIONFILTER`
    // 3. USING `PROBLEMDETAILS`
    // 4. HANDLING SPECIFIC EXCEPTIONS

    #region CREATE MIDDLEWARE CLASS
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "internal Server Error from the custom middleware."
            }.ToString());
        }
    }
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
    #endregion

    #region USING `ExceptionFilter`
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;
        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            _logger.LogError($"Exception occurred: {context.Exception}");
            context.Result = new JsonResult(new ErrorDetails()
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = "An Error occurred while processing your request."
            })
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        #region USING `ProblemDetails`
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var problemDetails = new ProblemDetails
            {
                Status = context.Response.StatusCode,
                Title = "An error occurred while processing your request.",
                Detail = exception.Message,
                Instance = context.Request.Path
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
        #endregion
    }
    #endregion

    #region HANDLING SPECIFIC EXCEPTIONS
    public class ExceptionMiddleware1
    {
        // ... other code

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is NotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Resource not found."
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error from the custom middleware."
            }.ToString());
        }
    }
    #endregion

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

    }
}
