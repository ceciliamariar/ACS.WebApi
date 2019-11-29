using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACS.WebApi.BaseDados.Migrations
{
    public partial class AppMigration001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataUltimaAtulizacao = table.Column<DateTime>(nullable: false),
                    IdUsuarioUltimaAtualicao = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Login = table.Column<string>(maxLength: 50, nullable: false),
                    Senha = table.Column<string>(maxLength: 50, nullable: false),
                    Perfil = table.Column<int>(nullable: false),
                    TipoPessoa = table.Column<int>(nullable: false),
                    IdUsuarioResponsavel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Usuarios_IdUsuarioResponsavel",
                        column: x => x.IdUsuarioResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Usuarios_IdUsuarioUltimaAtualicao",
                        column: x => x.IdUsuarioUltimaAtualicao,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataUltimaAtulizacao = table.Column<DateTime>(nullable: false),
                    IdUsuarioUltimaAtualicao = table.Column<int>(nullable: false),
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
                        name: "FK_Enderecos_Usuarios_IdUsuarioUltimaAtualicao",
                        column: x => x.IdUsuarioUltimaAtualicao,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Perguntas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataUltimaAtulizacao = table.Column<DateTime>(nullable: false),
                    IdUsuarioUltimaAtualicao = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perguntas_Usuarios_IdUsuarioUltimaAtualicao",
                        column: x => x.IdUsuarioUltimaAtualicao,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Remedios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataUltimaAtulizacao = table.Column<DateTime>(nullable: false),
                    IdUsuarioUltimaAtualicao = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remedios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Remedios_Usuarios_IdUsuarioUltimaAtualicao",
                        column: x => x.IdUsuarioUltimaAtualicao,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataUltimaAtulizacao = table.Column<DateTime>(nullable: false),
                    IdUsuarioUltimaAtualicao = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    Telefone = table.Column<string>(maxLength: 14, nullable: true),
                    Sexo = table.Column<string>(maxLength: 1, nullable: false),
                    IdEndereco = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Enderecos_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacientes_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacientes_Usuarios_IdUsuarioUltimaAtualicao",
                        column: x => x.IdUsuarioUltimaAtualicao,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataUltimaAtulizacao = table.Column<DateTime>(nullable: false),
                    IdUsuarioUltimaAtualicao = table.Column<int>(nullable: false),
                    DataHora = table.Column<DateTime>(nullable: false),
                    Rotina = table.Column<bool>(nullable: false),
                    Pedido = table.Column<bool>(nullable: false),
                    PAsist = table.Column<int>(nullable: false),
                    PAdist = table.Column<int>(nullable: false),
                    FC = table.Column<int>(nullable: false),
                    Comentario = table.Column<string>(maxLength: 500, nullable: true),
                    Validado = table.Column<bool>(nullable: false),
                    IdPaciente = table.Column<int>(nullable: false),
                    IdResponsavelCadastro = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicoes_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medicoes_Usuarios_IdResponsavelCadastro",
                        column: x => x.IdResponsavelCadastro,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medicoes_Usuarios_IdUsuarioUltimaAtualicao",
                        column: x => x.IdUsuarioUltimaAtualicao,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PacientesRemedios",
                columns: table => new
                {
                    IdRemedio = table.Column<int>(nullable: false),
                    IdPaciente = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataUltimaAtulizacao = table.Column<DateTime>(nullable: false),
                    IdUsuarioUltimaAtualicao = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataVisita = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacientesRemedios", x => new { x.IdPaciente, x.IdRemedio });
                    table.ForeignKey(
                        name: "FK_PacientesRemedios_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PacientesRemedios_Remedios_IdRemedio",
                        column: x => x.IdRemedio,
                        principalTable: "Remedios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PacientesRemedios_Usuarios_IdUsuarioUltimaAtualicao",
                        column: x => x.IdUsuarioUltimaAtualicao,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Respostas",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(nullable: false),
                    IdPergunta = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataUltimaAtulizacao = table.Column<DateTime>(nullable: false),
                    IdUsuarioUltimaAtualicao = table.Column<int>(nullable: false),
                    Respost = table.Column<bool>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataVisita = table.Column<DateTime>(nullable: false),
                    Validado = table.Column<bool>(nullable: false),
                    IdResponsavelCadastro = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respostas", x => new { x.IdPaciente, x.IdPergunta });
                    table.ForeignKey(
                        name: "FK_Respostas_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Respostas_Perguntas_IdPergunta",
                        column: x => x.IdPergunta,
                        principalTable: "Perguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Respostas_Usuarios_IdResponsavelCadastro",
                        column: x => x.IdResponsavelCadastro,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Respostas_Usuarios_IdUsuarioUltimaAtualicao",
                        column: x => x.IdUsuarioUltimaAtualicao,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdUsuarioUltimaAtualicao",
                table: "Enderecos",
                column: "IdUsuarioUltimaAtualicao");

            migrationBuilder.CreateIndex(
                name: "IX_Medicoes_IdPaciente",
                table: "Medicoes",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Medicoes_IdResponsavelCadastro",
                table: "Medicoes",
                column: "IdResponsavelCadastro");

            migrationBuilder.CreateIndex(
                name: "IX_Medicoes_IdUsuarioUltimaAtualicao",
                table: "Medicoes",
                column: "IdUsuarioUltimaAtualicao");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_IdEndereco",
                table: "Pacientes",
                column: "IdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_IdUsuario",
                table: "Pacientes",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_IdUsuarioUltimaAtualicao",
                table: "Pacientes",
                column: "IdUsuarioUltimaAtualicao");

            migrationBuilder.CreateIndex(
                name: "IX_PacientesRemedios_IdRemedio",
                table: "PacientesRemedios",
                column: "IdRemedio");

            migrationBuilder.CreateIndex(
                name: "IX_PacientesRemedios_IdUsuarioUltimaAtualicao",
                table: "PacientesRemedios",
                column: "IdUsuarioUltimaAtualicao");

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_IdUsuarioUltimaAtualicao",
                table: "Perguntas",
                column: "IdUsuarioUltimaAtualicao");

            migrationBuilder.CreateIndex(
                name: "IX_Remedios_IdUsuarioUltimaAtualicao",
                table: "Remedios",
                column: "IdUsuarioUltimaAtualicao");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_IdPergunta",
                table: "Respostas",
                column: "IdPergunta");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_IdResponsavelCadastro",
                table: "Respostas",
                column: "IdResponsavelCadastro");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_IdUsuarioUltimaAtualicao",
                table: "Respostas",
                column: "IdUsuarioUltimaAtualicao");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdUsuarioResponsavel",
                table: "Usuarios",
                column: "IdUsuarioResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdUsuarioUltimaAtualicao",
                table: "Usuarios",
                column: "IdUsuarioUltimaAtualicao");
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
