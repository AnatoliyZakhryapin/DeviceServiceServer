using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeviceServiceServer.Migrations
{
    /// <inheritdoc />
    public partial class SensorDataUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SensorId",
                table: "SensorDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SensorId",
                table: "SensorDatas");
        }
    }
}
