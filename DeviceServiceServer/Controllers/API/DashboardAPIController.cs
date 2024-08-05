using DeviceServiceServer.Data;
using DeviceServiceServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeviceServiceServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardAPIController : ControllerBase
    {
         [HttpGet("last/{sensorId}")]
        public async Task<IActionResult> GetLastSensorData(int sensorId)
        {
            //int sensorId = Convert.ToInt32(id);

            SensorData lastSensorData = await ServerManager.GetLastSensorDataAsync(sensorId);

            if (lastSensorData != null)
            {
                return Ok(new
                {
                    // Formattazione della temperatura con due decimali
                    value = lastSensorData.Value.ToString("F2"),

                    // Formattazione del timestamp
                    timestamp = lastSensorData.Timestamp.ToString("dd/MM/yyyy HH:mm:ss")
                });
            }

            return NotFound($"Not found data for sensor id {sensorId}");
        }
    }
}
