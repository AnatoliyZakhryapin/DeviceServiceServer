using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DeviceServiceServer.Models;

namespace DeviceServiceServer.Data
{
    public class DeviceServiceServerContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<SensorData> SensorDatas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DeviceServiceServer;Integrated Security=True;Pooling=False;Encrypt=False;TrustServerCertificate=False");
        }
    }
}
