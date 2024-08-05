using DeviceServiceServer.Data;
using DeviceServiceServer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DeviceServiceServer.Controllers.API
{
    [Route("api/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SaveDataFromDeviceServiceController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> StoreSensoreData([FromBody] JsonElement request)
        {
            if (request.ValueKind == JsonValueKind.Undefined)
            {
                return BadRequest("Request body is null");
            }


            try
            {
                List<SensorData> sensorDataList = JsonSerializer.Deserialize<List<SensorData>>(request.GetRawText());

                if (sensorDataList == null || sensorDataList.Count == 0)
                {
                    return BadRequest("No valid sensor data found in request.");
                }

                bool success = await ServerManager.AddNewSensorDatasAsync(sensorDataList);

                if (!success)
                {
                    return StatusCode(500, "Error saving sensor data to the database.");
                }

                return Ok("Request received and processed successfully.");
            }
            catch (JsonException ex)
            {
                return BadRequest($"JSON deserialization error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
