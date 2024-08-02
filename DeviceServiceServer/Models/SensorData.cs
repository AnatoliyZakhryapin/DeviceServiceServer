using System.ComponentModel.DataAnnotations;

namespace DeviceServiceServer.Models
{
    public class SensorData
    {
        public int SensorDataId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public double Value { get; set; }
        public int SensorId { get; set; }

        public SensorData(DateTime timestamp, string date, string time, double value) 
        { 
            Timestamp = timestamp;
            Date = date;
            Time = time;
            Value = value;
        }
    }
}
