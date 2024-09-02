using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PociDelivery.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PikatPostare",
                columns: table => new
                {
                    IDPikaPostare = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pikapostare = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Vendndodhja = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Statusi = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PikatPostare", x => x.IDPikaPostare);
                });

            migrationBuilder.CreateTable(
                name: "Rolet",
                columns: table => new
                {
                    IDRoli = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmerRoli = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rolet", x => x.IDRoli);
                });

            migrationBuilder.CreateTable(
                name: "Statuset",
                columns: table => new
                {
                    IDStatusi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmerStatusi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuset", x => x.IDStatusi);
                });

            migrationBuilder.CreateTable(
                name: "ZonatMbulimit",
                columns: table => new
                {
                    IDZonaMbulimit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPikaPostare = table.Column<int>(type: "int", nullable: false),
                    Zona = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonatMbulimit", x => x.IDZonaMbulimit);
                    table.ForeignKey(
                        name: "FK_ZonatMbulimit_PikatPostare_IDPikaPostare",
                        column: x => x.IDPikaPostare,
                        principalTable: "PikatPostare",
                        principalColumn: "IDPikaPostare",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Perdoruesit",
                columns: table => new
                {
                    IDPerdoruesi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fjalekalimi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Emri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mbiemri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IDRoli = table.Column<int>(type: "int", nullable: false),
                    IDPikaPostare = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perdoruesit", x => x.IDPerdoruesi);
                    table.ForeignKey(
                        name: "FK_Perdoruesit_PikatPostare_IDPikaPostare",
                        column: x => x.IDPikaPostare,
                        principalTable: "PikatPostare",
                        principalColumn: "IDPikaPostare");
                    table.ForeignKey(
                        name: "FK__Perdorues__IDRol__6E01572D",
                        column: x => x.IDRoli,
                        principalTable: "Rolet",
                        principalColumn: "IDRoli",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dergesat",
                columns: table => new
                {
                    IDDergesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDKlienti = table.Column<int>(type: "int", nullable: false),
                    IDSportelisti = table.Column<int>(type: "int", nullable: false),
                    EmriMarresit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MbiemriMarresit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdresaMarresit = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NumerTelefoni = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cmimi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDPikaPostare = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dergesat", x => x.IDDergesa);
                    table.ForeignKey(
                        name: "FK_Dergesat_Perdoruesit_IDKlienti",
                        column: x => x.IDKlienti,
                        principalTable: "Perdoruesit",
                        principalColumn: "IDPerdoruesi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dergesat_Perdoruesit_IDSportelisti",
                        column: x => x.IDSportelisti,
                        principalTable: "Perdoruesit",
                        principalColumn: "IDPerdoruesi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dergesat_PikatPostare_IDPikaPostare",
                        column: x => x.IDPikaPostare,
                        principalTable: "PikatPostare",
                        principalColumn: "IDPikaPostare",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paketat",
                columns: table => new
                {
                    IDPaketa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDTransportuesi = table.Column<int>(type: "int", nullable: false),
                    IDPikaPostareFillim = table.Column<int>(type: "int", nullable: false),
                    IDPikaPostareFund = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paketat", x => x.IDPaketa);
                    table.ForeignKey(
                        name: "FK_Paketat_Perdoruesit_IDTransportuesi",
                        column: x => x.IDTransportuesi,
                        principalTable: "Perdoruesit",
                        principalColumn: "IDPerdoruesi",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paketat_PikatPostare_IDPikaPostareFillim",
                        column: x => x.IDPikaPostareFillim,
                        principalTable: "PikatPostare",
                        principalColumn: "IDPikaPostare",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paketat_PikatPostare_IDPikaPostareFund",
                        column: x => x.IDPikaPostareFund,
                        principalTable: "PikatPostare",
                        principalColumn: "IDPikaPostare",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reportet",
                columns: table => new
                {
                    IDReporti = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPerdoruesi = table.Column<int>(type: "int", nullable: false),
                    Tipi = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Permbajtja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportet", x => x.IDReporti);
                    table.ForeignKey(
                        name: "FK_Reportet_Perdoruesit_IDPerdoruesi",
                        column: x => x.IDPerdoruesi,
                        principalTable: "Perdoruesit",
                        principalColumn: "IDPerdoruesi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusetDergesa",
                columns: table => new
                {
                    IDStatusiDergesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDStatusi = table.Column<int>(type: "int", nullable: false),
                    IDDergesa = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fshire = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusetDergesa", x => x.IDStatusiDergesa);
                    table.ForeignKey(
                        name: "FK_StatusetDergesa_Dergesat_IDDergesa",
                        column: x => x.IDDergesa,
                        principalTable: "Dergesat",
                        principalColumn: "IDDergesa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatusetDergesa_Statuset_IDStatusi",
                        column: x => x.IDStatusi,
                        principalTable: "Statuset",
                        principalColumn: "IDStatusi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatusetPaketa",
                columns: table => new
                {
                    IDStatusiPaketa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDStatusi = table.Column<int>(type: "int", nullable: false),
                    IDPaketa = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fshire = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusetPaketa", x => x.IDStatusiPaketa);
                    table.ForeignKey(
                        name: "FK_StatusetPaketa_Paketat_IDPaketa",
                        column: x => x.IDPaketa,
                        principalTable: "Paketat",
                        principalColumn: "IDPaketa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatusetPaketa_Statuset_IDStatusi",
                        column: x => x.IDStatusi,
                        principalTable: "Statuset",
                        principalColumn: "IDStatusi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dergesat_IDKlienti",
                table: "Dergesat",
                column: "IDKlienti");

            migrationBuilder.CreateIndex(
                name: "IX_Dergesat_IDPikaPostare",
                table: "Dergesat",
                column: "IDPikaPostare");

            migrationBuilder.CreateIndex(
                name: "IX_Dergesat_IDSportelisti",
                table: "Dergesat",
                column: "IDSportelisti");

            migrationBuilder.CreateIndex(
                name: "IX_Paketat_IDPikaPostareFillim",
                table: "Paketat",
                column: "IDPikaPostareFillim");

            migrationBuilder.CreateIndex(
                name: "IX_Paketat_IDPikaPostareFund",
                table: "Paketat",
                column: "IDPikaPostareFund");

            migrationBuilder.CreateIndex(
                name: "IX_Paketat_IDTransportuesi",
                table: "Paketat",
                column: "IDTransportuesi");

            migrationBuilder.CreateIndex(
                name: "IX_Perdoruesit_IDPikaPostare",
                table: "Perdoruesit",
                column: "IDPikaPostare");

            migrationBuilder.CreateIndex(
                name: "IX_Perdoruesit_IDRoli",
                table: "Perdoruesit",
                column: "IDRoli");

            migrationBuilder.CreateIndex(
                name: "IX_Reportet_IDPerdoruesi",
                table: "Reportet",
                column: "IDPerdoruesi");

            migrationBuilder.CreateIndex(
                name: "IX_StatusetDergesa_IDDergesa",
                table: "StatusetDergesa",
                column: "IDDergesa");

            migrationBuilder.CreateIndex(
                name: "IX_StatusetDergesa_IDStatusi",
                table: "StatusetDergesa",
                column: "IDStatusi");

            migrationBuilder.CreateIndex(
                name: "IX_StatusetPaketa_IDPaketa",
                table: "StatusetPaketa",
                column: "IDPaketa");

            migrationBuilder.CreateIndex(
                name: "IX_StatusetPaketa_IDStatusi",
                table: "StatusetPaketa",
                column: "IDStatusi");

            migrationBuilder.CreateIndex(
                name: "IX_ZonatMbulimit_IDPikaPostare",
                table: "ZonatMbulimit",
                column: "IDPikaPostare");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reportet");

            migrationBuilder.DropTable(
                name: "StatusetDergesa");

            migrationBuilder.DropTable(
                name: "StatusetPaketa");

            migrationBuilder.DropTable(
                name: "ZonatMbulimit");

            migrationBuilder.DropTable(
                name: "Dergesat");

            migrationBuilder.DropTable(
                name: "Paketat");

            migrationBuilder.DropTable(
                name: "Statuset");

            migrationBuilder.DropTable(
                name: "Perdoruesit");

            migrationBuilder.DropTable(
                name: "PikatPostare");

            migrationBuilder.DropTable(
                name: "Rolet");
        }
    }
}
