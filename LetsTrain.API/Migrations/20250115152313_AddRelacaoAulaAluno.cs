using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetsTrain.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRelacaoAulaAluno : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AulaAluno");

            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
