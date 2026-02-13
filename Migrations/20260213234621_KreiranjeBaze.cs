using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagerMVC.Migrations
{
    /// <inheritdoc />
    public partial class KreiranjeBaze : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Razredi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Smjer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GodinaUpisa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Razredi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ucenici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prosjek = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    RazredId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucenici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ucenici_Razredi_RazredId",
                        column: x => x.RazredId,
                        principalTable: "Razredi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ucenici_RazredId",
                table: "Ucenici",
                column: "RazredId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ucenici");

            migrationBuilder.DropTable(
                name: "Razredi");
        }
    }
}
