using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace caching_in_web_api.Controllers
{
    // Caching is a technique used to temporary store frequently accessed data in a cachce to improve
    // performance and reduce the load on resources such as databases and network calls. By serving
    // cached data, applications can respond more quickly to user requests and reduce latency.

    // Caching can be implemented both side Client-Side and Server-Side:

    // 1. Client-Side Caching -
    //                          It store responses on the client, usually in the browser cache. This type
    //                          of caching is controlled by HTTP headers such as `Cache-Control`,
    //                          'Expires` and `ETag`.

    //                          HTTP/1.1 200 OK
    //                          Cache-Control: max-age-3600
    //                          Expires: Wed, 21 Oct 2021 07:20:00 GMT
    //                          ETag: "abcd1234"
    //                          Content-Type: application/json
    //                          {
    //                              "Id": 1,
    //                              "name": "Product A"
    //                          }

    // 2. Server-Side Caching -
    //                         It Involved storing data on server to reduce the need to recompute results
    //                         or retrieve data from database frequently. This can be achieved using various
    //                         techniques, such as In-Memory Caching, file-based caching, or distributed
    //                         caching.

    

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMemoryCache _cache;                   // In-Memory Cache
        private readonly IProductRepository _repository;        // Dummy Repository
        private readonly IDistributedCache _distributeCache;    // Distribute Cache

        public HomeController(IMemoryCache cache, IDistributedCache distributeCache, IProductRepository repository)
        {
            _cache = cache;
            _distributeCache = distributeCache;
            _repository = repository;
        }

        #region In-Memory Caching In ASP.Net Core

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var cacheKey = $"Product_{id}";
            if (!_cache.TryGetValue(cacheKey, out Product product))
            {
                // Fetch product from database
                product = _repository.GetProductById(id);

                // Set cache options
                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                };

                // Save data in cache
                _cache.Set(cacheKey, product, cacheOptions);
            }
            return Ok(product);
        }

        #endregion

        #region Distribute Caching Using Redis in ASP.Net Core

        [HttpGet]
        public async Task<IActionResult> GetProductFromRedis(int id)
        {
            var cacheKey = $"Product_{id}";
            var cachedProduct = await _distributeCache.GetStringAsync(cacheKey);
            if(cachedProduct == null)
            {
                // Fetch Product from database
                var product = _repository.GetProductById(id);
                cachedProduct = JsonConvert.SerializeObject(product);

                // Save data in cache
                await _distributeCache.SetStringAsync(cacheKey, cachedProduct, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });
            }

            return Ok(JsonConvert.DeserializeObject<Product>(cachedProduct));
        }

        #endregion

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        public interface IProductRepository
        {
            Product GetProductById(int id);
            List<Product> GetAllProducts();
        }

        public class ProductRepository : IProductRepository
        {
            private readonly List<Product> _products;
            public ProductRepository()
            {
                // Simulate a data source wih a list of products
                _products = new List<Product>
                {
                    new Product { Id = 1, Name = "Product A", Price = 100.0m },
                    new Product { Id = 2, Name = "Product B", Price = 200.0m },
                    new Product { Id = 3, Name = "Product C", Price = 300.0m }
                };
            }
            public Product GetProductById(int id)
            {
                return _products.FirstOrDefault(p => p.Id == id);
            }
            public List<Product> GetAllProducts()
            {
                return _products;
            }
        }
    }
}
