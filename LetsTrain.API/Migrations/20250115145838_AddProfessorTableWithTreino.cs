using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetsTrain.API.Migrations
{
    /// <inheritdoc />
    public partial class AddProfessorTableWithTreino : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "Treinos",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Treinos_ProfessorId",
                table: "Treinos",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treinos_Professores_ProfessorId",
                table: "Treinos",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treinos_Professores_ProfessorId",
                table: "Treinos");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Treinos_ProfessorId",
                table: "Treinos");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Treinos");
        }
    }
}
