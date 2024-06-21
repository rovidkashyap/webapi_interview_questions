using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace return_type_in_webapi.Controllers
{
    // These are just demo code, just to show the return types. On running some of it shows compile-time error because
    // of not applied full method or services in the controller methods.
    // You just understand the concept of return types. For running code you will see in upcoming questions.

    // In .Net Core 6 Web API, the main return types are:

    // 1. Primitive Types (e.g., `string`, `int`) :
    //      - simple data types can be returned directly and ASP.Net Core will serialize them to the 
    //        appropriate format usually JSON) by default.

    // 2. Complex Types (e.g., Custom Model) :
    //      - Custom data models or objects can be returned and they will be serialized to JSON or XML.

    // 3. `IActionResult` :
    //      - Used to return different types of responses (e.g., status codes, content results).

    // 4. ActionResult<T> :
    //      - Used to return a specific model type along with status codes.

    // 5. `Task<T>` and `Task<IActionResult>` :
    //      - used for asynchronous operations. Equivalents of returning `T` or  `IActionResult`.

    // 6. `IEnumerable<T>` and `IQueryable<T>` :
    //      - Used to return collections of data. ASP.NET Core will seriralize the collection to JSON.

    // 7. `JsonResult` :
    //      - Used to return JSON data explicitly.

    // 8. `ContentResult` :
    //      - Used to return plain text or other types of content.

    // 9. `FileResult` :
    //      - Used to return Files, including static files, file streams or byte arrays.

    // 10. `EmptyResult` :
    //      - Used when you need to return an empty response.

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // Primitive Return Type
        [HttpGet]
        public string GetString()
        {
            return "Hello, World!";
        }

        // Complex Type
        [HttpGet]
        public MyModel GetModel()
        {
            return new MyModel { Id = 1, Name = "Example" };
        }

        public class MyModel
        {
            public int Id { get; set; }
            public string Name { get; set; } 
        }

        // IActionResult Return Type
        [HttpGet]
        public IActionResult GetResult()
        {
            int value = 5;
            if (value == 5)
            {
                return Ok(new { message = "Success" });
            }
            else
            {
                return NotFound();
            }
        }

        // ActionResult Return Type
        [HttpGet]
        public ActionResult GetActionResult()
        {
            var model = new MyModel { Id = 1, Name = "Example" };
            return Ok(model);
        }

        // `Task<T>` and `Task<IActionResult>` Return Type
        [HttpGet]
        public async Task<MyModel> GetAsync()
        {
            return await _service.GetModelAsync();  // No Implementation of Service class will throw compile-time error.
        }

        [HttpGet]
        public async Task<IActionResult> GetActionResultAsync()
        {
            var model = await _service.GetModelAsync(); // Same as above, not implemented service class throw compile-time error.
            return Ok(model);
        }

        // `IEnumerable<T>` and `IQueryable<T>` Return Type
        [HttpGet]
        public IEnumerable<MyModel> GetAll()
        {
            return _context.MyModel.ToList();   // Not Implemented context class will throw compile-time error.
        }

        // `JsonResult` Return Type
        [HttpGet]
        public JsonResult GetJson()
        {
            return new JsonResult(new { message = "Hello, World!" });
        }

        // `ContentResult` Return Type
        [HttpGet]
        public ContentResult GetContent()
        {
            return Content("Hello, World!", "text/plain");
        }

        // `FileResult` Return Type
        public FileResult GetFile()
        {
            var bytes = System.IO.File.ReadAllBytes("path_to_fiile");
            return File(bytes, "application/octet-stream", "filename.ext");
        }

        // `EmptyResult` Return Type
        [HttpGet]
        public EmptyResult GetEmpty()
        {
            return new EmptyResult();
        }
    }
}
