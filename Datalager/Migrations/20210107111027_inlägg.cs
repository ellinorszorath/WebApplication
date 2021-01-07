using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datalager.Migrations
{
    public partial class inlägg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inlägg",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skapad = table.Column<DateTime>(nullable: false),
                    AnvändareId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inlägg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inlägg_AspNetUsers_AnvändareId",
                        column: x => x.AnvändareId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inlägg_AnvändareId",
                table: "Inlägg",
                column: "AnvändareId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inlägg");
        }
    }
}
