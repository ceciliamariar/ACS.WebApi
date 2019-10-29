using Microsoft.EntityFrameworkCore.Migrations;

namespace ACS.WebApi.BaseDados.Migrations
{
    public partial class AppMigration002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Respostas");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Remedios");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Perguntas");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "PacientesRemedios");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Medicoes");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Enderecos");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Pacientes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "Medicoes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Respostas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Remedios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Perguntas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "PacientesRemedios",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Pacientes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Pacientes",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "Medicoes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Medicoes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Enderecos",
                nullable: true);
        }
    }
}
