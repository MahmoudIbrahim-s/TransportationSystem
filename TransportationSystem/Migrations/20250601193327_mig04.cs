using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportationSystem.Migrations
{
    /// <inheritdoc />
    public partial class mig04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartLocation",
                table: "BusRoutes",
                newName: "StartPoint");

            migrationBuilder.RenameColumn(
                name: "EndLocation",
                table: "BusRoutes",
                newName: "EndPoint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartPoint",
                table: "BusRoutes",
                newName: "StartLocation");

            migrationBuilder.RenameColumn(
                name: "EndPoint",
                table: "BusRoutes",
                newName: "EndLocation");
        }
    }
}
