using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datalager.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inlägg_AspNetUsers_MottagareId",
                table: "Inlägg");

            migrationBuilder.DropForeignKey(
                name: "FK_Inlägg_AspNetUsers_SenderId",
                table: "Inlägg");

            migrationBuilder.DropIndex(
                name: "IX_Inlägg_MottagareId",
                table: "Inlägg");

            migrationBuilder.DropIndex(
                name: "IX_Inlägg_SenderId",
                table: "Inlägg");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Inlägg");

            migrationBuilder.DropColumn(
                name: "MottagareId",
                table: "Inlägg");

            migrationBuilder.DropColumn(
                name: "Användarnamn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Bild",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Lösenord",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "SkickareID",
                table: "Inlägg",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MottagareID",
                table: "Inlägg",
                type: "nvarchar(max)",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepterad",
                table: "Vänförfrågning");

            migrationBuilder.DropColumn(
                name: "FörfrågareID",
                table: "Vänförfrågning");

            migrationBuilder.DropColumn(
                name: "FörfrågningsDatum",
                table: "Vänförfrågning");

            migrationBuilder.DropColumn(
                name: "SkickareID",
                table: "Inlägg");

            migrationBuilder.RenameColumn(
                name: "MottagareID",
                table: "Vänförfrågning",
                newName: "MottagareId");

            migrationBuilder.RenameColumn(
                name: "MottagareID",
                table: "Inlägg",
                newName: "MottagareId");

            migrationBuilder.AlterColumn<string>(
                name: "MottagareId",
                table: "Vänförfrågning",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MottagareId",
                table: "Inlägg",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "Inlägg",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Födelsedatum",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Användarnamn",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Bild",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lösenord",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vänförfrågning_MottagareId",
                table: "Vänförfrågning",
                column: "MottagareId");

            migrationBuilder.CreateIndex(
                name: "IX_Inlägg_MottagareId",
                table: "Inlägg",
                column: "MottagareId");

            migrationBuilder.CreateIndex(
                name: "IX_Inlägg_SenderId",
                table: "Inlägg",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inlägg_AspNetUsers_MottagareId",
                table: "Inlägg",
                column: "MottagareId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inlägg_AspNetUsers_SenderId",
                table: "Inlägg",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vänförfrågning_AspNetUsers_MottagareId",
                table: "Vänförfrågning",
                column: "MottagareId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
