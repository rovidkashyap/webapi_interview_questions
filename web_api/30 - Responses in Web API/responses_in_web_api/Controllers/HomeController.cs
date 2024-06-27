using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace responses_in_web_api.Controllers
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class HomeController : ControllerBase
    {
        #region Primitive Type and Complex Type
        // 1. Returning Primitive Types (e.g., `string`, `int`) and Complex Types (e.g., objects)

        [HttpGet]
        public string GetPrimitive()
        {
            return "Hello, world!";
        }

        [HttpGet]
        public IActionResult GetComplex()
        {
            var product = new Product { Id = 1, Name = "Sample Product", Price = 19.99m };
            return Ok(product);
        }
        #endregion

        #region IActionResult and ActionResult<T>
        [HttpGet("actionresult")]
        public IActionResult GetActionResult()
        {
            var product = new Product { Id = 1, Name = "Sample Product", Price = 19.99m };
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet("actionresult-generic")]
        public ActionResult<Product> GetActionResultGeneric()
        {
            var product = new Product { Id = 1, Name = "Sample Product", Price = 19.99m };
            return product;
        }
        #endregion

        #region Return Specific Status Codes
        [HttpGet("statuscode")]
        public IActionResult GetStatusCode()
        {
            return StatusCode(200);     // Returns a 200 OK status code
        }

        [HttpGet("notfound")]
        public IActionResult GetNotFound()
        {
            return NotFound();          // Returns a 4040 Not Found status code
        }

        [HttpPost("created")]
        public IActionResult PostCreated()
        {
            var product = new Product { Id = 1, Name = "New Product", Price = 29.99m };
            
            // Returns a 201 Created status code
            return CreatedAtAction(nameof(GetActionResult), new { id = product.Id }, product);
        }
        #endregion

        #region Returning No Content
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            // Logic to delete the product
            return NoContent();     // Returns a 204 No Content status code
        }
        #endregion

        #region Returning Custom Responses
        [HttpGet("customresponse")]
        public IActionResult GetCustomResponse()
        {
            var content = "This is a custom response";
            return Content(content, "text/plain");      // Returns a custom plain text response
        }
        #endregion

        #region Handling Errors and Exceptions
        [HttpGet("error")]
        public IActionResult GetError()
        {
            try
            {
                // Logic that might throw an exception
                throw new Exception("Something went wrong");
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });   // Returns a 500 Internal Server error status code
            }
        }
        #endregion

        #region Returning Files
        [HttpGet("file")]
        public IActionResult GetFile()
        {
            var filePath = "path/to/file.txt";
            var fileBytes = System.IO.File.ReadAllBytes(filePath);

            // Returns a file response
            return File(fileBytes, "application/octet-stream", "file.txt");
        }
        #endregion

    }
}
