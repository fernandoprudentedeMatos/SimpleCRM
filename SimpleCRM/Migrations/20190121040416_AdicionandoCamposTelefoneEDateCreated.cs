using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleCRM.Migrations
{
    public partial class AdicionandoCamposTelefoneEDateCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Costumers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Costumers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Costumers");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Costumers");
        }
    }
}
