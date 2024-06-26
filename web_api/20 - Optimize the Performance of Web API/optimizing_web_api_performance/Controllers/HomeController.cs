using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace optimizing_web_api_performance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /*
            Here are some best practices and techniques for optimizing the performance of your
            ASP.Net Core Web API :

            1. Use Asynchronous Programming -
                    - Use asychronous programming with `async` and `await` keywords. Asynchronous
                    methods free up threads to handle more requests concurrently.
            
            2. Optimize Data Access -
                    - Use efficient data access pattern and technologies like Entity Framework Core,
                    Dapper or ADO.NET.

            3. Caching -
                    - Implement cahcing to store frequently accessed data and reduce database load.
                    - Use In-Memory cahcing for quick access to data.

            4. Use Response Compression -
                    - Enable response compression to reduce the size of the data sent to clients,
                    improving load times.
                    - services.AddResponseCompression(options => {
                           options.Providers.Add<BrotilCompressionProvider>();
                           options.Providers.Add<GzipCompressionProvider>();
                    });
            
            5. Minimize Middleware - 
                    - Minimize the number of middleware components in the request pipeline to reduce
                    overhead.
                    - Place critical middleware components, such as authentication and authorization,
                    early in the pipeline.

            6. Use Content Delivery Network (CDN) -
                    - use a CDN to serve static content like images, CSS and JavaScript files.

            7. Load Balancing -
                    - Implement Load Balancing to distribute incoming requests across multiple servers,
                    improving scalability and fault tolerance.

            8. Optimize Startup Configuration -
                    - Minimize the statup time be deferring service instantiation until they are needed.
                    - Use Lazy Loading for services and dependencies.
            
            9. Profiling and Monitoring -
                    - Profile your application to identify bottlenecks using tools like Application Insight,
                    MiniProfiler, or ELMAH.

            10. Use HTTP/2 -
                    - Enable HTTP/2 to benefits from features like multiplexing, header compression, and
                    server push.

            11. Optimize JSON Serialization -
                    - Optimize JSON Serialization by configuring JSON options to reduce payload size.

            12. Connection Pooling -
                    - Enable connection pooling for database connections to reduce the overhead of establishing
                    connections.

            13. Avoid Overfetching and Underfetching -
                    - Use DTOs (Data Transfer Objects) to return only the required data, avoiding overfetching
                    and underfetching issues.

        */
    }
}
