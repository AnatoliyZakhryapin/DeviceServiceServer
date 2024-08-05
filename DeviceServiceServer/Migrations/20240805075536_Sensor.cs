using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeviceServiceServer.Migrations
{
    /// <inheritdoc />
    public partial class Sensor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    SensorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SensorSerialNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.SensorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorDatas_SensorId",
                table: "SensorDatas",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_SensorSerialNumber",
                table: "Sensors",
                column: "SensorSerialNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SensorDatas_Sensors_SensorId",
                table: "SensorDatas",
                column: "SensorId",
                principalTable: "Sensors",
                principalColumn: "SensorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SensorDatas_Sensors_SensorId",
                table: "SensorDatas");

            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropIndex(
                name: "IX_SensorDatas_SensorId",
                table: "SensorDatas");
        }
    }
}
