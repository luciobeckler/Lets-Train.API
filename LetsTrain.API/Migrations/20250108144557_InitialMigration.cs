using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetsTrain.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesoEmKg = table.Column<float>(type: "real", nullable: false),
                    AlturaEmM = table.Column<float>(type: "real", nullable: false),
                    Graduacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DiaVencimentoMatricula = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Graduacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuracaoEmMinutos = table.Column<int>(type: "int", nullable: false),
                    ProfessoresId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treinos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treinos_Professores_ProfessoresId",
                        column: x => x.ProfessoresId,
                        principalTable: "Professores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantMaximaAlunos = table.Column<int>(type: "int", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecorrenciaEmDias = table.Column<int>(type: "int", nullable: true),
                    TreinosId = table.Column<int>(type: "int", nullable: false),
                    ProfessoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aulas_Professores_ProfessoresId",
                        column: x => x.ProfessoresId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aulas_Treinos_TreinosId",
                        column: x => x.TreinosId,
                        principalTable: "Treinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Repeticoes = table.Column<int>(type: "int", nullable: false),
                    TreinosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercicios_Treinos_TreinosId",
                        column: x => x.TreinosId,
                        principalTable: "Treinos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AlunosAulas",
                columns: table => new
                {
                    AlunosId = table.Column<int>(type: "int", nullable: false),
                    AulasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosAulas", x => new { x.AlunosId, x.AulasId });
                    table.ForeignKey(
                        name: "FK_AlunosAulas_Alunos_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosAulas_Aulas_AulasId",
                        column: x => x.AulasId,
                        principalTable: "Aulas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosAulas_AulasId",
                table: "AlunosAulas",
                column: "AulasId");

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_ProfessoresId",
                table: "Aulas",
                column: "ProfessoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_TreinosId",
                table: "Aulas",
                column: "TreinosId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_TreinosId",
                table: "Exercicios",
                column: "TreinosId");

            migrationBuilder.CreateIndex(
                name: "IX_Treinos_ProfessoresId",
                table: "Treinos",
                column: "ProfessoresId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosAulas");

            migrationBuilder.DropTable(
                name: "Exercicios");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Aulas");

            migrationBuilder.DropTable(
                name: "Treinos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
