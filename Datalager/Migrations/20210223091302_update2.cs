using Microsoft.EntityFrameworkCore.Migrations;

namespace Datalager.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Visas",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visas",
                table: "AspNetUsers");
        }
    }
}
