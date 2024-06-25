using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace error_handling_in_webapi.Controllers
{
    // Error Handling in .Net Core 6 Web API invovles several key components
    // and techniques to ensure robust and clear error responses.

    // 1. Global Exception Handling Middleware - This catches exceptions that occure during the processing
    //                                          of HTTP requests and returns a consistent error response.
    
    // 2. Using `Exception Filters` - This handle exception thrown by actions in controllers. They are
    //                                  useful for catching and handle exceptions on a per-controller
    //                                  or per-action basis.

    // 3. Validation and Model State Errors - Model validation is a common source of errors, ASP.NET Core
    //                                          provides built-in support for model validation.

    // 4. Consistent Error Response Format - Ensure that all errors, regardless of where they occur,
    //                                          follow a consistent response format. This makes it easier
    //                                          for clients to handle errors.

    #region Using Global Exception Handling Middleware
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Unhandled Exception has occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                statusCode = context.Response.StatusCode,
                message = "Internal Server Error from the custom middleware.",
                detailed = exception.Message
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
    #endregion

    #region Using Exception Filters
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;
        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "An unhandled exception has occurred.");

            var response = new
            {
                statusCode = (int)HttpStatusCode.InternalServerError,
                message = "Internal Server Error from the custom exception filter.",
                detailed = context.Exception.Message
            };

            context.Result = new JsonResult(response)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
    #endregion

    #region Validation and Model State Error
    public class MyModel
    {
        [Required]
        public string Name { get; set; }
    }
    #endregion

    #region Consistent Error Response Format
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Detailed { get; set; }
    }
    #endregion

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // Register `Exception Filters` on specific Controller/Action.
        [ServiceFilter(typeof(CustomExceptionFilter))]  
        public IActionResult Get()
        {
            throw new Exception("Test Exception");
        }

        [HttpPost]
        public IActionResult Post([FromBody] MyModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { message = "Validation Errors", errors });
            }

            // Process valid model
            return Ok();
        }
    }
}
