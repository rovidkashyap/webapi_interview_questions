using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace global_exception_handling_in_web_api.Controllers
{
    // Global exception handling in ASP.NET Core Web API ensures that all unhandled exceptions are
    // caught and managed in a centralized way, providing consistent error responses and improving
    // the maintainability and robustness of your API.

    // Steps to Implement Global Exception Handling in ASP.Net Core Web API
    // 1. Create a Custom Exception Middleware
    // 2. Register the Middleware in the Request Pipeline
    // 3. Optional: Customize Exception Responses

    #region Creating Custom Exception Middleware
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
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorDetails = new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error from the custom middleware."
            };

            return context.Response.WriteAsync(errorDetails.ToString());
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
    }
    #endregion

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

    }
}
