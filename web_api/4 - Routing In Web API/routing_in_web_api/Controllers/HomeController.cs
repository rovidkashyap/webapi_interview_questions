using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace routing_in_web_api.Controllers
{
    // Routing is the Process of mapping HTTP Request to the corresponding controller actions. Several Types of Routing:

    // 1. Conventional Routing - It has predefined pattern to map URLs to controller actions. It is typically defined
    //                              in `Program.cs` file. You can check `Program.cs` for Conventional Routing example.

    // 2. Attribute Routing - It uses atributes to define route directly on controller actions. This provides more 
    //                              control over individual routes and is useful for creating RESTful APIs.

    // 3. Endpoint Routing - Introduce in ASP.NET Core 3.0, endpoint routing decouples the route matching and
    //                              endpoint execution processes. It provides a unified way to define routing
    //                              for MVC, Razor Pages, and other middleware.


    [Route("api/[controller]")]     // Example of Attirbute Routing
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok();
        }

        [HttpGet("{Id}")]
        public IActionResult GetProductById(int id)
        {
            // Implementation
            return Ok(id);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            var result = (new Product { Id = 1, Name = "Flower Pot", Details = "Home Decor Products" });
            return Ok(result);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
    }
}
