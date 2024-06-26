using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hateos_in_restful_api.Controllers
{
    /*
        HATEOAS (Hypermedia As The Engine Of Application State) is a constraint of the REST 
        (Representational State Transfer) application architecture. It is one of the key principles 
        that define a truly RESTful service. HATEOAS provides clients with information about how to 
        interact with the RESTful web service dynamically by including hypermedia links with 
        responses.
    */

    //1. Define the Model
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Link> Links { get; set; } = new List<Link>();
    }
    public class Link
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }
    }

    // 2. Create a Helper Method to Generate Links
    // Check the Link Generator File.

    // 3. Update the Controller to Include Links in Responses
    // Check the Product Controller.

    // 4. When you run the web api and access this api using POSTMAN or SWAGGER or any other tool
    //      you will get ouput like this:

    /*
        {
            "id":1,
            "name": "Sample Product",
            "price": 99.99,        
            "links": [
                {
                    "href": "https://localhost:5001/api/products/1",
                    "rel": "self",
                    "method": "GET"
                },
                {
                    "href": "https://localhost:5001/api/products/1",
                    "rel": "update_product",
                    "method": "PUT"
                },
                {
                    "href": "https://localhost:5001/api/products/1",
                    "rel": "delete_product",
                    "method": "DELETE"
                }
            ]
        }
    */
}
