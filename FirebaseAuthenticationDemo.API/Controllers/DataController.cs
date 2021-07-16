using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirebaseAuthenticationDemo.API.Controllers
{
    [ApiController]
    public class DataController : ControllerBase
    {
        [Authorize]
        [HttpGet("/")]
        public IActionResult GetData()
        {
            return Ok();
        }
    }
}
