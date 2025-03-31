using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetsTrain.API.Migrations
{
    /// <inheritdoc />
    public partial class RebrandingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Professores_ProfessorId",
                table: "Aulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Treinos_TreinoId",
                table: "Aulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercicios_Treinos_TreinoId",
                table: "Exercicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Treinos_Professores_ProfessorId",
                table: "Treinos");

            migrationBuilder.DropTable(
                name: "AulaAluno");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorId",
                table: "Treinos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TreinoId",
                table: "Exercicios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TreinoId",
                table: "Aulas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorId",
                table: "Aulas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AlunoAula",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    AulasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoAula", x => new { x.AlunoId, x.AulasId });
                    table.ForeignKey(
                        name: "FK_AlunoAula_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoAula_Aulas_AulasId",
                        column: x => x.AulasId,
                        principalTable: "Aulas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoAula_AulasId",
                table: "AlunoAula",
                column: "AulasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Professores_ProfessorId",
                table: "Aulas",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Treinos_TreinoId",
                table: "Aulas",
                column: "TreinoId",
                principalTable: "Treinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercicios_Treinos_TreinoId",
                table: "Exercicios",
                column: "TreinoId",
                principalTable: "Treinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treinos_Professores_ProfessorId",
                table: "Treinos",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Professores_ProfessorId",
                table: "Aulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Treinos_TreinoId",
                table: "Aulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercicios_Treinos_TreinoId",
                table: "Exercicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Treinos_Professores_ProfessorId",
                table: "Treinos");

            migrationBuilder.DropTable(
                name: "AlunoAula");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorId",
                table: "Treinos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TreinoId",
                table: "Exercicios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TreinoId",
                table: "Aulas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorId",
                table: "Aulas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "AulaAluno",
                columns: table => new
                {
                    AulaId = table.Column<int>(type: "int", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AulaAluno", x => new { x.AulaId, x.AlunoId });
                    table.ForeignKey(
                        name: "FK_AulaAluno_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AulaAluno_Aulas_AulaId",
                        column: x => x.AulaId,
                        principalTable: "Aulas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AulaAluno_AlunoId",
                table: "AulaAluno",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Professores_ProfessorId",
                table: "Aulas",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Treinos_TreinoId",
                table: "Aulas",
                column: "TreinoId",
                principalTable: "Treinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercicios_Treinos_TreinoId",
                table: "Exercicios",
                column: "TreinoId",
                principalTable: "Treinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Treinos_Professores_ProfessorId",
                table: "Treinos",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
