using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace request_lifecycle_of_web_api.Controllers
{

    // The lifecycle of a Web API requests in ASP.Net Core involves several stages from the moment a
    // request is received until a response is sent back to the client.

    /*
     
    1. HTTP Request Received -                 When a client sends an HTTP request to the server, it 
                                               is first received by the web server (e.g., Kestrel in 
                                               ASP.Net Core).

    2. Server Processing -                     The web server forwards the request to the ASP.Net 
                                               Core middleware pipeline.

    3. Middleware Pipeline Execution -         ASP.Net Core processes the request through a series 
                                               of middleware components. Middleware are peices of 
                                               code that handle requests and responses and can 
                                               perform operations such as logging, authentication, 
                                               routing, etc.
            
            3.1. Request Delegation -          Each middleware component can either:
                                               - Pass the request to next middleware in the pipeline.
                                               - Short-circuit the pipeline by generating a response.

    4. Routing Middleware -                    The routing middleware matches the incoming request 
                                               to a route defined in the application. If a matching 
                                               route is found, the request forwarded to the 
                                               corresponding controller and action method.

    5. Model Binding and Validation -          Before reaching the action method, ASP.Net Core 
                                               performs model binding and validations.

            5.1. Model Binding -               The framework binds the incoming request data to the 
                                               action method parameters.

            5.2. Validation -                  Data annotations and custom validation logic are 
                                               executed to ensure that the data is valid.

    6. Controller Instantiation -              If the request is routed to a controller action, 
                                               ASP.Net Core creates an instance of the controller 
                                               (if it's not already created)

    7. Action Method Execution -               The matched action method on the controller is executed. 
                                               This method contains the business logic to process 
                                               the request.

    8. Result Creation -                       The action method typically returns an `IActionResult`
                                               or `ActionResult` (e.g.,`OkResult`, `NotFoundResult`, 
                                               `JsonResult`, etc.). This result represents the response 
                                               that will be sent back to the client.

    9. Result Execution -                      The ASP.Net Core framework executes the result, which 
                                               involves:
            
            9.1. - Formatting the Response -   The result is serialized into the appropriate format
                                               (e.g., JSON, XML) based on content negotiation.

            9.2. - Response Headers -          Setting appropriate HTTP response headers.

    10. Response Sent to Middleware Pipeline - The response is sent back through the middleware 
                                               pipeline, allowing any response-processing middleware
                                               to perform final operations (e.g., logging the 
                                               response).

    11. Response Sent to Client -              The response is finally sent back to the client by 
                                               the web server.
          
    */

    /*
     
    SUMMARY -

    1. HTTP Request Received : The Web Server recieves the HTTP request.

    2. Middleware Pipeline Execution: Request passes through various middleware components.

    3. Routing Middleware: Routes the request to the appropriate controller and action method.

    4. Model Binding and Validation: Binds requests data to method parameters and perform validations.

    5. Controller Instantiation: Creates the controller instance.

    6. Action Method Execution: Executes the action method logic.

    7. Result Creation and Execution: Creates and serializes the result, sets response headers.

    8. Response Sent to Client: Sends the response back to the client.

    */
}
