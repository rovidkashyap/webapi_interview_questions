using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IActionResult_in_web_api.Controllers
{
    // `IActionResult` is common return type for controller actions, providing flexibility to return types of responses,
    // such as HTML views, JSON data, status codes and more.

    // Product Model for demonstration prupose
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // In-memory list of products for demonstration purposes
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1000 },
            new Product { Id = 2, Name = "Smartphone", Price = 500 }
        };

        // GET: api/products
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(products);    // Returns 200 OK status code with product data serialized as JSON
        }

        // GET :api/products/1
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);     // Returns 200 OK status using `Ok()`, if not found returns 404 `NotFound()`
        }

        // POST: api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);     // Return 400 `BadRequest()` if modelstate is invalid.
            }
            products.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);   // Return 201 Created status with the location of new product.
        }

        // PUT: api/products/1
        public IActionResult UpdateProduct(int id, [FromBody] Product updateProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if(product == null)
            {
                return NotFound();      // Return 404 `NotFound()` Error if not found data.
            }

            product.Name = updateProduct.Name;
            product.Price = updateProduct.Price;
            return NoContent();         // Returns 204 `NoContent()` and updates Data.
        }

        // DELETE: api/products/1
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if(product == null)
            {
                return NotFound();      // Return 404 `NotFound()` Error if not found data.
            }

            products.Remove(product);
            return NoContent();         // Returns 204 `NoContent()` and remove the data.
        }
    }
}
