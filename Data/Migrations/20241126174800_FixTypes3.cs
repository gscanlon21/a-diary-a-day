using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTypes3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VitaminA",
                table: "user_urine");

            migrationBuilder.DropColumn(
                name: "VitaminA",
                table: "user_serum_female_health");

            migrationBuilder.RenameColumn(
                name: "Homocysteine",
                table: "user_urine",
                newName: "SpecificGravity");

            migrationBuilder.RenameColumn(
                name: "Homocysteine",
                table: "user_serum_female_health",
                newName: "TotalTestosterone");

            migrationBuilder.AddColumn<double>(
                name: "Albumin",
                table: "user_urine",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Bilirubin",
                table: "user_urine",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Glucose",
                table: "user_urine",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Ketones",
                table: "user_urine",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Leukocyte",
                table: "user_urine",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Nitrate",
                table: "user_urine",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OccultBlood",
                table: "user_urine",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PH",
                table: "user_urine",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Protein",
                table: "user_urine",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DHEASulfate",
                table: "user_serum_female_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "E2",
                table: "user_serum_female_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FSH",
                table: "user_serum_female_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FreePSA",
                table: "user_serum_female_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FreePSAPercent",
                table: "user_serum_female_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FreeTestosterone",
                table: "user_serum_female_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LH",
                table: "user_serum_female_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Prolactin",
                table: "user_serum_female_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SHBG",
                table: "user_serum_female_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalPSA",
                table: "user_serum_female_health",
                type: "double precision",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Albumin",
                table: "user_urine");

            migrationBuilder.DropColumn(
                name: "Bilirubin",
                table: "user_urine");

            migrationBuilder.DropColumn(
                name: "Glucose",
                table: "user_urine");

            migrationBuilder.DropColumn(
                name: "Ketones",
                table: "user_urine");

            migrationBuilder.DropColumn(
                name: "Leukocyte",
                table: "user_urine");

            migrationBuilder.DropColumn(
                name: "Nitrate",
                table: "user_urine");

            migrationBuilder.DropColumn(
                name: "OccultBlood",
                table: "user_urine");

            migrationBuilder.DropColumn(
                name: "PH",
                table: "user_urine");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "user_urine");

            migrationBuilder.DropColumn(
                name: "DHEASulfate",
                table: "user_serum_female_health");

            migrationBuilder.DropColumn(
                name: "E2",
                table: "user_serum_female_health");

            migrationBuilder.DropColumn(
                name: "FSH",
                table: "user_serum_female_health");

            migrationBuilder.DropColumn(
                name: "FreePSA",
                table: "user_serum_female_health");

            migrationBuilder.DropColumn(
                name: "FreePSAPercent",
                table: "user_serum_female_health");

            migrationBuilder.DropColumn(
                name: "FreeTestosterone",
                table: "user_serum_female_health");

            migrationBuilder.DropColumn(
                name: "LH",
                table: "user_serum_female_health");

            migrationBuilder.DropColumn(
                name: "Prolactin",
                table: "user_serum_female_health");

            migrationBuilder.DropColumn(
                name: "SHBG",
                table: "user_serum_female_health");

            migrationBuilder.DropColumn(
                name: "TotalPSA",
                table: "user_serum_female_health");

            migrationBuilder.RenameColumn(
                name: "SpecificGravity",
                table: "user_urine",
                newName: "Homocysteine");

            migrationBuilder.RenameColumn(
                name: "TotalTestosterone",
                table: "user_serum_female_health",
                newName: "Homocysteine");

            migrationBuilder.AddColumn<int>(
                name: "VitaminA",
                table: "user_urine",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VitaminA",
                table: "user_serum_female_health",
                type: "integer",
                nullable: true);
        }
    }
}
