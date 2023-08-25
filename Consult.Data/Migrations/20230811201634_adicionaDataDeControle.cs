using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Consult.Data.Migrations
{
    public partial class adicionaDataDeControle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Criacao",
                table: "Pacientes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Pacientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Criacao",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Pacientes");
        }
    }
}
