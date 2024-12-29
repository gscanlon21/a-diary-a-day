using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGeneStudySnp2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attributes",
                table: "study_snp");

            migrationBuilder.DropColumn(
                name: "Measure",
                table: "study_snp");

            migrationBuilder.DropColumn(
                name: "Optional",
                table: "study_snp");

            migrationBuilder.DropColumn(
                name: "QuantityDenominator",
                table: "study_snp");

            migrationBuilder.DropColumn(
                name: "QuantityNumerator",
                table: "study_snp");

            migrationBuilder.AddColumn<string>(
                name: "EffectAllele",
                table: "study_snp",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "study_snp",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EffectAllele",
                table: "study_snp");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "study_snp");

            migrationBuilder.AddColumn<string>(
                name: "Attributes",
                table: "study_snp",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Measure",
                table: "study_snp",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Optional",
                table: "study_snp",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "QuantityDenominator",
                table: "study_snp",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityNumerator",
                table: "study_snp",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
