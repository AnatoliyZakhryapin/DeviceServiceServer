using DeviceServiceServer.Migrations;
using DeviceServiceServer.Models;
using Microsoft.EntityFrameworkCore;
using SensorData = DeviceServiceServer.Models.SensorData;

namespace DeviceServiceServer.Data
{
    public static class ServerManager
    {
        public static async Task<bool> AddNewSensorDataAsync(SensorData sensorData)
        {
            await using DeviceServiceServerContext context = new DeviceServiceServerContext();
            try
            {
                await context.AddAsync(sensorData);
                await context.SaveChangesAsync();
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine($"Error adding sensor data asynchronously: {ex.Message}");
                return false;
            }
        }

        public static async Task<bool> AddNewSensorDatasAsync(List<Models.SensorData> sensorDatas)
        {
            await using DeviceServiceServerContext context = new DeviceServiceServerContext();

            try
            {
                await context.AddRangeAsync(sensorDatas);
                await context.SaveChangesAsync();
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine($"Error adding sensor data list asynchronously: {ex.Message}");
                return false;
            }
        }

        public static async Task<SensorData?> GetLastSensorDataAsync(int sensorId)
        {
            await using DeviceServiceServerContext context = new DeviceServiceServerContext();

            SensorData lastSensorData = await context.SensorDatas.Where(sd => sd.SensorId == sensorId).OrderByDescending(sd => sd.Timestamp)
                                                 .FirstOrDefaultAsync();
            if (lastSensorData == null)
            {
                return null;
            }

            return lastSensorData;
        }
    }
}
