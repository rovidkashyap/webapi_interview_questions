using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace exception_filter.Controllers
{
    // Exception Filters in Web APi are powerful mechanism for handling exceptions that occur during
    // the execution of an action method. They provide a way to catch exceptions, log them and return
    // custom response to the client.
    // Exception Filters are applied `GLOBALLY`, at the `CONTROLLER LEVEL`, or at `ACTION LEVEL`.
    // Exceptiom Filters are applied using `Depenedency Injection`.

    // For creating Exception Filter just implement `ExceptionFilter` or `IAsyncExceptionFilter` interface.

    #region Custom Exception Filter
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

            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Title = "An error occurred while processing your request.",
                Detail = context.Exception.Message,
                Instance = context.HttpContext.Request.Path
            };
            context.Result = new ObjectResult(problemDetails)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
            context.ExceptionHandled = true;    // Mark the exception as handled
        }
    }
    #endregion

    // If you want to register Exception Filter globally, then see Program.cs file where we register
    // this filter globally to application.

    [ServiceFilter(typeof(CustomExceptionFilter))]  // This is way to register at `Controller Level`.
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [ServiceFilter(typeof(CustomExceptionFilter))]  // This is way to register at `Action Level`.
        public IActionResult Get()
        {
            throw new Exception("Test Exception");
        }
    }
}
