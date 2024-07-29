using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeviceServiceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
