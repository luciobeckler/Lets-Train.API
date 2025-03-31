using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetsTrain.API.Migrations
{
    /// <inheritdoc />
    public partial class AllowNullRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Treinos_TreinoId",
                table: "Aulas");

            migrationBuilder.AlterColumn<int>(
                name: "TreinoId",
                table: "Aulas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Treinos_TreinoId",
                table: "Aulas",
                column: "TreinoId",
                principalTable: "Treinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Treinos_TreinoId",
                table: "Aulas");

            migrationBuilder.AlterColumn<int>(
                name: "TreinoId",
                table: "Aulas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Treinos_TreinoId",
                table: "Aulas",
                column: "TreinoId",
                principalTable: "Treinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
