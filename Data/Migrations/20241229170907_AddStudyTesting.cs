using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStudyTesting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_study_snp_SNPId",
                table: "study");

            migrationBuilder.DropIndex(
                name: "IX_study_SNPId",
                table: "study");

            migrationBuilder.DropColumn(
                name: "SNPId",
                table: "study");

            migrationBuilder.CreateTable(
                name: "study_snp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SNPId = table.Column<int>(type: "integer", nullable: false),
                    StudyId = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: true),
                    IngredientRecipeId = table.Column<int>(type: "integer", nullable: true),
                    QuantityNumerator = table.Column<int>(type: "integer", nullable: false),
                    QuantityDenominator = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Optional = table.Column<bool>(type: "boolean", nullable: false),
                    Measure = table.Column<int>(type: "integer", nullable: false),
                    Attributes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_study_snp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_study_snp_snp_SNPId",
                        column: x => x.SNPId,
                        principalTable: "snp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_study_snp_study_StudyId",
                        column: x => x.StudyId,
                        principalTable: "study",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_study_snp_SNPId",
                table: "study_snp",
                column: "SNPId");

            migrationBuilder.CreateIndex(
                name: "IX_study_snp_StudyId",
                table: "study_snp",
                column: "StudyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "study_snp");

            migrationBuilder.AddColumn<int>(
                name: "SNPId",
                table: "study",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_study_SNPId",
                table: "study",
                column: "SNPId");

            migrationBuilder.AddForeignKey(
                name: "FK_study_snp_SNPId",
                table: "study",
                column: "SNPId",
                principalTable: "snp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
