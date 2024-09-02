using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PociDelivery.Migrations
{
    public partial class UpdateDBStatusiZM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Statusi",
                table: "ZonatMbulimit",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Statusi",
                table: "ZonatMbulimit");
        }
    }
}
