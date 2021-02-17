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
                    Message = table.Column<string>(nullable: true),
                    Skapad = table.Column<DateTime>(nullable: false),
                    SenderId = table.Column<string>(nullable: true),
                    MottagareId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inlägg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inlägg_AspNetUsers_MottagareId",
                        column: x => x.MottagareId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inlägg_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inlägg_MottagareId",
                table: "Inlägg",
                column: "MottagareId");

            migrationBuilder.CreateIndex(
                name: "IX_Inlägg_SenderId",
                table: "Inlägg",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inlägg");
        }
    }
}
