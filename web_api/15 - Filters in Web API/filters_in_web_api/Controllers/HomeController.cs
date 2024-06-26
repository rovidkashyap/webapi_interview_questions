using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace filters_in_web_api.Controllers
{
    // Filters in Web API are attribute that allow developers to execute custom logic at various points
    // within the requests processing pipeline. They provide a way to handle cross-cutting concerns such
    // as authentication, authorization, logging, error handling, and more.

    // FILTERS CAN BE APPLY AT GLOBAL LEVEL, CONTROLLER LEVEL, OR AT ACTION LEVEL.

    // TYPES OF FILTERS IN WEB API -
    
    // 1. Authorization Filters - These Filter are used to perform authentication and authorization logic
    //                            before the action method is executed.

    // 2. Action Filters - These Filters are used to perform operations before and after action method
    //                      is executed.

    // 3. Result Filters - These Filters are used to perofrm operations before and after action result
    //                      is executed. They are useful for modifying the response before it is sent
    //                      to the client.

    // 4. Exception Filters - These Filters are used to handle unhandled exceptions that occur during 
    //                          the action methods. They allow developers to log the exception or return
    //                          a custom error response.

    #region Authorization Filters
    public class CustomAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            // Custom Authorized Logic
            return base.IsAuthorized(actionContext);
        }
    }
    #endregion

    #region Action Filters
    public class CustomActionFilterAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // Code that run before the action method
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            // Code that run after the action method
            base.OnActionExecuted(actionExecutedContext);
        }
    }
    #endregion

    #region Result Filters
    public class CustomResultFilterAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // Code that runs before the action result
            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            // Code that runs after the action result
            base.OnResultExecuted(context);
        }
    }
    #endregion

    #region Exception Filters
    public class CustomExceptionFilterAttribute : System.Web.Http.Filters.ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            // Custom exception handling logic
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An error occurred. Please try again later."),
                ReasonPhrase = "Internal Server Error"
            };
            context.Response = response;
        }
    }
    #endregion

    [CustomAuthorize]       // Authorization Filter Usage
    [CustomActionFilter]    // Action Filter Usage
    [CustomResultFilter]    // Result Filters Usage
    [CustomExceptionFilter] // Exception Filters Usage
    public class HomeController : ApiController
    {
        public IHttpActionResult GetProduct(int id)
        {
            // Action Method Logic
            return Ok();
        }
    }
}
