using Microsoft.EntityFrameworkCore.Migrations;

namespace Consult.Data.Migrations
{
    public partial class addtelefones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Pacientes");

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    PacienteId = table.Column<int>(nullable: false),
                    Numero = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => new { x.PacienteId, x.Numero });
                    table.ForeignKey(
                        name: "FK_Telefones_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}