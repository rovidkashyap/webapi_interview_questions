using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Web.Http;

namespace mediatype_formatters.Controllers
{
    // Media Type Formatters are responsible for handling content negotitation and data serialization/
    // deserialization between HTTP requests and .Net objects.

    // 1. JsonMediaTypeFormatter - Handles JSON response data.
    // 2. XmlMediaTypeFormatter - Handles XML response data.
    // 3. FormUrlEncodedMediaTypeFormatter - Handles Form URL-Encoded data.

    public class HomeController : ApiController
    {
        #region JsonMediaTypeFormatter
        // GET api/home
        public IEnumerable<Product> Get()
        {
            // Assume getching products from a data source
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 19.99m },
                new Product { Id = 2, Name = "Product 2", Price = 29.99m }
            };

            return products;
        }

        // POST api/home
        public IHttpActionResult POST(Product product)
        {
            // Assusme saving the product to a data source
            // Here, `product` is automatically bound from JSON in the request body
            return Ok(product);
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
        #endregion
    }
}
