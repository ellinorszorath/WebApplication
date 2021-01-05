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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(nullable: true),
                    Efternamn = table.Column<string>(nullable: true),
                    Användarnamn = table.Column<string>(nullable: true),
                    Födelsedatum = table.Column<DateTime>(nullable: false),
                    Lösenord = table.Column<string>(nullable: true),
                    Vänförfrågningar = table.Column<int>(nullable: true)
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
