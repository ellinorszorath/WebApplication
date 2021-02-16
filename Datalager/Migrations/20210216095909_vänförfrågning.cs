using Microsoft.EntityFrameworkCore.Migrations;

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
                    MottagareId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vänförfrågning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vänförfrågning_AspNetUsers_MottagareId",
                        column: x => x.MottagareId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vänförfrågning_MottagareId",
                table: "Vänförfrågning",
                column: "MottagareId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vänförfrågning");
        }
    }
}
