using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Consult.Data.Migrations
{
    public partial class adicionaDatasDeControle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Criacao",
                table: "Pacientes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAtualizacao",
                table: "Pacientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Criacao",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizacao",
                table: "Pacientes");
        }
    }
}