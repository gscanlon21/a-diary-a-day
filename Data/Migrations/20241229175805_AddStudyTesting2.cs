using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStudyTesting2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_study_snp_snp_SNPId",
                table: "study_snp");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "study_snp");

            migrationBuilder.DropColumn(
                name: "IngredientRecipeId",
                table: "study_snp");

            migrationBuilder.AlterColumn<int>(
                name: "SNPId",
                table: "study_snp",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_study_snp_snp_SNPId",
                table: "study_snp",
                column: "SNPId",
                principalTable: "snp",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_study_snp_snp_SNPId",
                table: "study_snp");

            migrationBuilder.AlterColumn<int>(
                name: "SNPId",
                table: "study_snp",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "study_snp",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredientRecipeId",
                table: "study_snp",
                type: "integer",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_study_snp_snp_SNPId",
                table: "study_snp",
                column: "SNPId",
                principalTable: "snp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
