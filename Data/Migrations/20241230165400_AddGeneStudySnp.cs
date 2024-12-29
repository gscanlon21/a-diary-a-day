using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGeneStudySnp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneId",
                table: "study_snp",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_study_snp_GeneId",
                table: "study_snp",
                column: "GeneId");

            migrationBuilder.AddForeignKey(
                name: "FK_study_snp_gene_GeneId",
                table: "study_snp",
                column: "GeneId",
                principalTable: "gene",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_study_snp_gene_GeneId",
                table: "study_snp");

            migrationBuilder.DropIndex(
                name: "IX_study_snp_GeneId",
                table: "study_snp");

            migrationBuilder.DropColumn(
                name: "GeneId",
                table: "study_snp");
        }
    }
}
