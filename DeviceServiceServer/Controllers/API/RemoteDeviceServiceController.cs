using DeviceServiceServer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeviceServiceServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoteDeviceServiceController : ControllerBase
    {
        private readonly RemoteDeviceServiceClient _remoteDeviceServiceClient;

        public RemoteDeviceServiceController(RemoteDeviceServiceClient remoteDeviceServiceClient)
        {
            _remoteDeviceServiceClient = remoteDeviceServiceClient;
        }

        [HttpPost]
        public async Task<IActionResult> ManageDeviceService(string command)
        {
            // Verifica che il comando sia valido
            if (command != "start" && command != "stop" && command != "restart")
            {
                return BadRequest("Comando non valido.");
            }

            // Invia il comando al DeviceService tramite RemoteDevuceServiceClient
            var result = await _remoteDeviceServiceClient.SendCommand(command);

            // Restituisce il risultato alla vista
            return Ok(result);
        }
    }
}
