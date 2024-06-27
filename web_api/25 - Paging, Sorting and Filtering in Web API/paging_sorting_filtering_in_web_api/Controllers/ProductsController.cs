using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using paging_sorting_filtering_in_web_api.Models;

namespace paging_sorting_filtering_in_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductQueryParameters queryParameters)
        {
            var products = await _repository.GetProductAsync(queryParameters);
            var totalProducts = await _repository.GetTotalCountAsync();

            var response = new
            {
                TotalCount = totalProducts,
                PageSize = queryParameters.PageSize,
                CurrentPage = queryParameters.PageNumber,
                TotalPages = (int)Math.Ceiling(totalProducts / (double)queryParameters.PageSize),
                Products = products
            };

            return Ok(response);
        }
    }
}
