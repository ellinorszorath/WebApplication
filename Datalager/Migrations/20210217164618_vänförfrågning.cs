using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Datalager.Migrations
{
    public partial class vänförfrågning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vänförfrågning",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MottagareID = table.Column<string>(nullable: true),
                    FörfrågareID = table.Column<string>(nullable: true),
                    FörfrågningsDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Accepterad = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vänförfrågning", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vänförfrågning");
        }
    }
}
