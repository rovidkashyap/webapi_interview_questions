using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace authorization_in_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        // This action requires authentication
        [Authorize]
        [HttpGet("protected")]
        public IActionResult GetProtectedData()
        {
            return Ok("This is protected data.");
        }

        // This action requires the user to be in the "Admin" role
        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult GetAdminData()
        {
            return Ok("This is admin data.");
        }

        // This action requires the "AdminOnly" policy
        [Authorize(Policy = "AdminOnly")]
        [HttpGet("policy")]
        public IActionResult GetPolicyData()
        {
            return Ok("This data is protected by the AdminOnly Policy.");
        }
    }
}
