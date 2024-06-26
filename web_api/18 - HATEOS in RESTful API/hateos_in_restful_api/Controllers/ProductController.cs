using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hateos_in_restful_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUrlHelper _urlHelper;
        public ProductController(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        [HttpGet("{id}", Name = nameof(GetProductById))]
        public IActionResult GetProductById(int id)
        {
            var product = new Product
            {
                Id = id,
                Name = "Sample Product",
                Price = 99.99M,
            };

            product.Links = LinkGenerator.GenerateLinks(id, _urlHelper);
            return Ok(product);
        }

        [HttpPut("{id}", Name = nameof(UpdateProduct))]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            // Update product Logic
            return NoContent();
        }

        [HttpDelete("{id}", Name = nameof(DeleteProduct))]
        public IActionResult DeleteProduct(int id)
        {
            // Delete Product Logic
            return NoContent();
        }
    }
}
