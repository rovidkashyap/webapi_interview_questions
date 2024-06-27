using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace delegatinghandler_in_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ApiService _apiService;
        public DataController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _apiService.GetDataAsync();
            return Ok(data);
        }
    }
}
