using Microsoft.EntityFrameworkCore;

namespace DeviceServiceServer.Models
{
    [Index (nameof(SensorSerialNumber), IsUnique = true)]
    public class Sensor
    {
        public int SensorId { get; set; }
        public string SensorSerialNumber { get; set; }

        public List<SensorData> SensorData { get; set; }
    }
}
