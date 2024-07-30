using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeviceServiceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DataController : ControllerBase
    {
        [HttpPost]
        public IActionResult StoreSensoreData([FromBody] object request)
        {
            if (request == null)
            {
                return BadRequest("Request body is null");
            }

            return Ok("Request received and processed successfully.");
        }
    }
}
