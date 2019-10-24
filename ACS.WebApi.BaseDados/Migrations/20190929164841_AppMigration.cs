using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACS.WebApi.BaseDados.Migrations
{
    public partial class AppMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataUltimaAtulizacao = table.Column<DateTime>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    UsuarioUltimaAtualizacaoId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Login = table.Column<string>(maxLength: 50, nullable: false),
                    Senha = table.Column<string>(maxLength: 50, nullable: false),
                    Perfil = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Usuarios_UsuarioUltimaAtualizacaoId",
                        column: x => x.UsuarioUltimaAtualizacaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataUltimaAtulizacao = table.Column<DateTime>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    UsuarioUltimaAtualizacaoId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 200, nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(maxLength: 100, nullable: true),
                    Cidade = table.Column<string>(maxLength: 100, nullable: true),
                    CEP = table.Column<string>(maxLength: 100, nullable: false),
                    GeoLocalizacao = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Usuarios_UsuarioUltimaAtualizacaoId",
                        column: x => x.UsuarioUltimaAtualizacaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Perguntas",
                columns: table => new
                {
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataUltimaAtulizacao = table.Column<DateTime>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    UsuarioUltimaAtualizacaoId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perguntas_Usuarios_UsuarioUltimaAtualizacaoId",
                        column: x => x.UsuarioUltimaAtualizacaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Remedios",
                columns: table => new
                {
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataUltimaAtulizacao = table.Column<DateTime>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    UsuarioUltimaAtualizacaoId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remedios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Remedios_Usuarios_UsuarioUltimaAtualizacaoId",
                        column: x => x.UsuarioUltimaAtualizacaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataUltimaAtulizacao = table.Column<DateTime>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    UsuarioUltimaAtualizacaoId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    Telefone = table.Column<string>(maxLength: 14, nullable: true),
                    Sexo = table.Column<string>(maxLength: 1, nullable: false),
                    IdEndereco = table.Column<int>(nullable: false),
                    EnderecoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacientes_Usuarios_UsuarioUltimaAtualizacaoId",
                        column: x => x.UsuarioUltimaAtualizacaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicoes",
                columns: table => new
                {
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataUltimaAtulizacao = table.Column<DateTime>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    UsuarioUltimaAtualizacaoId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdPaciente = table.Column<int>(nullable: false),
                    DataHora = table.Column<DateTime>(nullable: false),
                    Rotina = table.Column<bool>(nullable: false),
                    Pedido = table.Column<bool>(nullable: false),
                    PAsist = table.Column<int>(nullable: false),
                    PAdist = table.Column<int>(nullable: false),
                    FC = table.Column<int>(nullable: false),
                    Comentario = table.Column<string>(maxLength: 500, nullable: true),
                    PacienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicoes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medicoes_Usuarios_UsuarioUltimaAtualizacaoId",
                        column: x => x.UsuarioUltimaAtualizacaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PacientesRemedios",
                columns: table => new
                {
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataUltimaAtulizacao = table.Column<DateTime>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    UsuarioUltimaAtualizacaoId = table.Column<int>(nullable: true),
                    IdRemedio = table.Column<int>(nullable: false),
                    IdPaciente = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataVisita = table.Column<DateTime>(nullable: false),
                    RemedioId = table.Column<int>(nullable: true),
                    PacienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacientesRemedios", x => new { x.IdPaciente, x.IdRemedio });
                    table.ForeignKey(
                        name: "FK_PacientesRemedios_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PacientesRemedios_Remedios_RemedioId",
                        column: x => x.RemedioId,
                        principalTable: "Remedios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PacientesRemedios_Usuarios_UsuarioUltimaAtualizacaoId",
                        column: x => x.UsuarioUltimaAtualizacaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Respostas",
                columns: table => new
                {
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataUltimaAtulizacao = table.Column<DateTime>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    UsuarioUltimaAtualizacaoId = table.Column<int>(nullable: true),
                    IdPaciente = table.Column<int>(nullable: false),
                    IdPergunta = table.Column<int>(nullable: false),
                    Respost = table.Column<bool>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataVisita = table.Column<DateTime>(nullable: false),
                    PerguntaId = table.Column<int>(nullable: true),
                    PacienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respostas", x => new { x.IdPaciente, x.IdPergunta });
                    table.ForeignKey(
                        name: "FK_Respostas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Respostas_Perguntas_PerguntaId",
                        column: x => x.PerguntaId,
                        principalTable: "Perguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Respostas_Usuarios_UsuarioUltimaAtualizacaoId",
                        column: x => x.UsuarioUltimaAtualizacaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_UsuarioUltimaAtualizacaoId",
                table: "Enderecos",
                column: "UsuarioUltimaAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicoes_PacienteId",
                table: "Medicoes",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicoes_UsuarioUltimaAtualizacaoId",
                table: "Medicoes",
                column: "UsuarioUltimaAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_EnderecoId",
                table: "Pacientes",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_UsuarioUltimaAtualizacaoId",
                table: "Pacientes",
                column: "UsuarioUltimaAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PacientesRemedios_PacienteId",
                table: "PacientesRemedios",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PacientesRemedios_RemedioId",
                table: "PacientesRemedios",
                column: "RemedioId");

            migrationBuilder.CreateIndex(
                name: "IX_PacientesRemedios_UsuarioUltimaAtualizacaoId",
                table: "PacientesRemedios",
                column: "UsuarioUltimaAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_UsuarioUltimaAtualizacaoId",
                table: "Perguntas",
                column: "UsuarioUltimaAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Remedios_UsuarioUltimaAtualizacaoId",
                table: "Remedios",
                column: "UsuarioUltimaAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_PacienteId",
                table: "Respostas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_PerguntaId",
                table: "Respostas",
                column: "PerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_UsuarioUltimaAtualizacaoId",
                table: "Respostas",
                column: "UsuarioUltimaAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioUltimaAtualizacaoId",
                table: "Usuarios",
                column: "UsuarioUltimaAtualizacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicoes");

            migrationBuilder.DropTable(
                name: "PacientesRemedios");

            migrationBuilder.DropTable(
                name: "Respostas");

            migrationBuilder.DropTable(
                name: "Remedios");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Perguntas");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
