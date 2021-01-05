using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datalager.Migrations
{
    public partial class skapapersontabell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registrering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efternamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Användarnamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Födelsedatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lösenord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vänförfrågningar = table.Column<string>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrering", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrering");
        }
    }
}
