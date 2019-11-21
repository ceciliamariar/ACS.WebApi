using Microsoft.EntityFrameworkCore.Migrations;

namespace ACS.WebApi.BaseDados.Migrations
{
    public partial class AppMigration003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioUltimaAtualicao",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoPessoa",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioUltimaAtualicao",
                table: "Respostas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioUltimaAtualicao",
                table: "Remedios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioUltimaAtualicao",
                table: "Perguntas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioUltimaAtualicao",
                table: "PacientesRemedios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Pacientes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioUltimaAtualicao",
                table: "Pacientes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioResponsavelId",
                table: "Pacientes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioUltimaAtualicao",
                table: "Medicoes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioUltimaAtualicao",
                table: "Enderecos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_UsuarioResponsavelId",
                table: "Pacientes",
                column: "UsuarioResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Usuarios_UsuarioResponsavelId",
                table: "Pacientes",
                column: "UsuarioResponsavelId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Usuarios_UsuarioResponsavelId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_UsuarioResponsavelId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "IdUsuarioUltimaAtualicao",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TipoPessoa",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdUsuarioUltimaAtualicao",
                table: "Respostas");

            migrationBuilder.DropColumn(
                name: "IdUsuarioUltimaAtualicao",
                table: "Remedios");

            migrationBuilder.DropColumn(
                name: "IdUsuarioUltimaAtualicao",
                table: "Perguntas");

            migrationBuilder.DropColumn(
                name: "IdUsuarioUltimaAtualicao",
                table: "PacientesRemedios");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "IdUsuarioUltimaAtualicao",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "UsuarioResponsavelId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "IdUsuarioUltimaAtualicao",
                table: "Medicoes");

            migrationBuilder.DropColumn(
                name: "IdUsuarioUltimaAtualicao",
                table: "Enderecos");
        }
    }
}
