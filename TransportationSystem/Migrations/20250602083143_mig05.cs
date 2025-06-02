using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportationSystem.Migrations
{
    /// <inheritdoc />
    public partial class mig05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCapacityFull",
                table: "Buses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCapacityFull",
                table: "Buses");
        }
    }
}
