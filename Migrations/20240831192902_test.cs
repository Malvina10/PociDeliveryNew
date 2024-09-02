using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PociDelivery.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Perdorues__IDRol__6E01572D",
                table: "Perdoruesit");

            migrationBuilder.AlterColumn<int>(
                name: "IDRoli",
                table: "Perdoruesit",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK__Perdorues__IDRol__6E01572D",
                table: "Perdoruesit",
                column: "IDRoli",
                principalTable: "Rolet",
                principalColumn: "IDRoli");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Perdorues__IDRol__6E01572D",
                table: "Perdoruesit");

            migrationBuilder.AlterColumn<int>(
                name: "IDRoli",
                table: "Perdoruesit",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__Perdorues__IDRol__6E01572D",
                table: "Perdoruesit",
                column: "IDRoli",
                principalTable: "Rolet",
                principalColumn: "IDRoli",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
