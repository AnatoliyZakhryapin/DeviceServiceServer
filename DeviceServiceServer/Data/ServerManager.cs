using DeviceServiceServer.Migrations;

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
    }
}
