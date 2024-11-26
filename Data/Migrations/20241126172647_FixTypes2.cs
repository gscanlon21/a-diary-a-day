using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTypes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VitaminA",
                table: "user_serum_thyroid");

            migrationBuilder.DropColumn(
                name: "VitaminA",
                table: "user_serum_nutrients");

            migrationBuilder.DropColumn(
                name: "VitaminA",
                table: "user_serum_metabolic");

            migrationBuilder.DropColumn(
                name: "VitaminA",
                table: "user_serum_male_health");

            migrationBuilder.DropColumn(
                name: "VitaminA",
                table: "user_serum_liver");

            migrationBuilder.DropColumn(
                name: "VitaminA",
                table: "user_serum_kidney");

            migrationBuilder.DropColumn(
                name: "VitaminA",
                table: "user_serum_immune_regulation");

            migrationBuilder.DropColumn(
                name: "VitaminA",
                table: "user_serum_heart");

            migrationBuilder.DropColumn(
                name: "VitaminA",
                table: "user_serum_electolytes");

            migrationBuilder.DropColumn(
                name: "VitaminA",
                table: "user_serum_blood");

            migrationBuilder.RenameColumn(
                name: "Homocysteine",
                table: "user_serum_thyroid",
                newName: "TgAb");

            migrationBuilder.RenameColumn(
                name: "Homocysteine",
                table: "user_serum_metabolic",
                newName: "UricAcid");

            migrationBuilder.RenameColumn(
                name: "Homocysteine",
                table: "user_serum_male_health",
                newName: "TotalTestosterone");

            migrationBuilder.RenameColumn(
                name: "Homocysteine",
                table: "user_serum_liver",
                newName: "Protein");

            migrationBuilder.RenameColumn(
                name: "Homocysteine",
                table: "user_serum_kidney",
                newName: "Sodium");

            migrationBuilder.RenameColumn(
                name: "Homocysteine",
                table: "user_serum_immune_regulation",
                newName: "WBCCount");

            migrationBuilder.RenameColumn(
                name: "Homocysteine",
                table: "user_serum_heart",
                newName: "Triglycerides");

            migrationBuilder.RenameColumn(
                name: "Homocysteine",
                table: "user_serum_electolytes",
                newName: "Sodium");

            migrationBuilder.RenameColumn(
                name: "Homocysteine",
                table: "user_serum_blood",
                newName: "RDW");

            migrationBuilder.AddColumn<double>(
                name: "T3",
                table: "user_serum_thyroid",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "T4",
                table: "user_serum_thyroid",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TPO",
                table: "user_serum_thyroid",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TSH",
                table: "user_serum_thyroid",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Calcium",
                table: "user_serum_nutrients",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Ferritin",
                table: "user_serum_nutrients",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Iron",
                table: "user_serum_nutrients",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "IronBindingCapacity",
                table: "user_serum_nutrients",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "IronSat",
                table: "user_serum_nutrients",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MMA",
                table: "user_serum_nutrients",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Magnesium",
                table: "user_serum_nutrients",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VitaminD",
                table: "user_serum_nutrients",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Zinc",
                table: "user_serum_nutrients",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Glucose",
                table: "user_serum_metabolic",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HbA1c",
                table: "user_serum_metabolic",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Insulin",
                table: "user_serum_metabolic",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Leptin",
                table: "user_serum_metabolic",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DHEASulfate",
                table: "user_serum_male_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "E2",
                table: "user_serum_male_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FSH",
                table: "user_serum_male_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FreePSA",
                table: "user_serum_male_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FreePSAPercent",
                table: "user_serum_male_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FreeTestosterone",
                table: "user_serum_male_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LH",
                table: "user_serum_male_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Prolactin",
                table: "user_serum_male_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SHBG",
                table: "user_serum_male_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalPSA",
                table: "user_serum_male_health",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ALP",
                table: "user_serum_liver",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ALT",
                table: "user_serum_liver",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AST",
                table: "user_serum_liver",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Albumin",
                table: "user_serum_liver",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AlbuminGlobulin",
                table: "user_serum_liver",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Bilirubin",
                table: "user_serum_liver",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GGT",
                table: "user_serum_liver",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Globulin",
                table: "user_serum_liver",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AlbuminUrine",
                table: "user_serum_kidney",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BUN",
                table: "user_serum_kidney",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Calcium",
                table: "user_serum_kidney",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Chloride",
                table: "user_serum_kidney",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Creatinine",
                table: "user_serum_kidney",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "EGFR",
                table: "user_serum_kidney",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Potassium",
                table: "user_serum_kidney",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Basophilis",
                table: "user_serum_immune_regulation",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BasophilisPercent",
                table: "user_serum_immune_regulation",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Eosinophilis",
                table: "user_serum_immune_regulation",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "EosinophilisPercent",
                table: "user_serum_immune_regulation",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HsCRP",
                table: "user_serum_immune_regulation",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lymphocytes",
                table: "user_serum_immune_regulation",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LymphocytesPercent",
                table: "user_serum_immune_regulation",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Monocytes",
                table: "user_serum_immune_regulation",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MonocytesPercent",
                table: "user_serum_immune_regulation",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Neutrophilis",
                table: "user_serum_immune_regulation",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NeutrophilisPercent",
                table: "user_serum_immune_regulation",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HDLCholesterol",
                table: "user_serum_heart",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HDLLarge",
                table: "user_serum_heart",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HsCRP",
                table: "user_serum_heart",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LDLCholesterol",
                table: "user_serum_heart",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LDLMedium",
                table: "user_serum_heart",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LDLParticleNumber",
                table: "user_serum_heart",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LDLPattern",
                table: "user_serum_heart",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LDLPeakSize",
                table: "user_serum_heart",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LDLSmall",
                table: "user_serum_heart",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LipoproteinA",
                table: "user_serum_heart",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NonHDLCholesterol",
                table: "user_serum_heart",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalCholesterol",
                table: "user_serum_heart",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalCholesterolHDL",
                table: "user_serum_heart",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Calcium",
                table: "user_serum_electolytes",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CarbonDioxide",
                table: "user_serum_electolytes",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Chloride",
                table: "user_serum_electolytes",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Magnesium",
                table: "user_serum_electolytes",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Potassium",
                table: "user_serum_electolytes",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Hematocrit",
                table: "user_serum_blood",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Hemoglobin",
                table: "user_serum_blood",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MCH",
                table: "user_serum_blood",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MCHC",
                table: "user_serum_blood",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MCV",
                table: "user_serum_blood",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MPV",
                table: "user_serum_blood",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PlateletCount",
                table: "user_serum_blood",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RBCCount",
                table: "user_serum_blood",
                type: "double precision",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "T3",
                table: "user_serum_thyroid");

            migrationBuilder.DropColumn(
                name: "T4",
                table: "user_serum_thyroid");

            migrationBuilder.DropColumn(
                name: "TPO",
                table: "user_serum_thyroid");

            migrationBuilder.DropColumn(
                name: "TSH",
                table: "user_serum_thyroid");

            migrationBuilder.DropColumn(
                name: "Calcium",
                table: "user_serum_nutrients");

            migrationBuilder.DropColumn(
                name: "Ferritin",
                table: "user_serum_nutrients");

            migrationBuilder.DropColumn(
                name: "Iron",
                table: "user_serum_nutrients");

            migrationBuilder.DropColumn(
                name: "IronBindingCapacity",
                table: "user_serum_nutrients");

            migrationBuilder.DropColumn(
                name: "IronSat",
                table: "user_serum_nutrients");

            migrationBuilder.DropColumn(
                name: "MMA",
                table: "user_serum_nutrients");

            migrationBuilder.DropColumn(
                name: "Magnesium",
                table: "user_serum_nutrients");

            migrationBuilder.DropColumn(
                name: "VitaminD",
                table: "user_serum_nutrients");

            migrationBuilder.DropColumn(
                name: "Zinc",
                table: "user_serum_nutrients");

            migrationBuilder.DropColumn(
                name: "Glucose",
                table: "user_serum_metabolic");

            migrationBuilder.DropColumn(
                name: "HbA1c",
                table: "user_serum_metabolic");

            migrationBuilder.DropColumn(
                name: "Insulin",
                table: "user_serum_metabolic");

            migrationBuilder.DropColumn(
                name: "Leptin",
                table: "user_serum_metabolic");

            migrationBuilder.DropColumn(
                name: "DHEASulfate",
                table: "user_serum_male_health");

            migrationBuilder.DropColumn(
                name: "E2",
                table: "user_serum_male_health");

            migrationBuilder.DropColumn(
                name: "FSH",
                table: "user_serum_male_health");

            migrationBuilder.DropColumn(
                name: "FreePSA",
                table: "user_serum_male_health");

            migrationBuilder.DropColumn(
                name: "FreePSAPercent",
                table: "user_serum_male_health");

            migrationBuilder.DropColumn(
                name: "FreeTestosterone",
                table: "user_serum_male_health");

            migrationBuilder.DropColumn(
                name: "LH",
                table: "user_serum_male_health");

            migrationBuilder.DropColumn(
                name: "Prolactin",
                table: "user_serum_male_health");

            migrationBuilder.DropColumn(
                name: "SHBG",
                table: "user_serum_male_health");

            migrationBuilder.DropColumn(
                name: "TotalPSA",
                table: "user_serum_male_health");

            migrationBuilder.DropColumn(
                name: "ALP",
                table: "user_serum_liver");

            migrationBuilder.DropColumn(
                name: "ALT",
                table: "user_serum_liver");

            migrationBuilder.DropColumn(
                name: "AST",
                table: "user_serum_liver");

            migrationBuilder.DropColumn(
                name: "Albumin",
                table: "user_serum_liver");

            migrationBuilder.DropColumn(
                name: "AlbuminGlobulin",
                table: "user_serum_liver");

            migrationBuilder.DropColumn(
                name: "Bilirubin",
                table: "user_serum_liver");

            migrationBuilder.DropColumn(
                name: "GGT",
                table: "user_serum_liver");

            migrationBuilder.DropColumn(
                name: "Globulin",
                table: "user_serum_liver");

            migrationBuilder.DropColumn(
                name: "AlbuminUrine",
                table: "user_serum_kidney");

            migrationBuilder.DropColumn(
                name: "BUN",
                table: "user_serum_kidney");

            migrationBuilder.DropColumn(
                name: "Calcium",
                table: "user_serum_kidney");

            migrationBuilder.DropColumn(
                name: "Chloride",
                table: "user_serum_kidney");

            migrationBuilder.DropColumn(
                name: "Creatinine",
                table: "user_serum_kidney");

            migrationBuilder.DropColumn(
                name: "EGFR",
                table: "user_serum_kidney");

            migrationBuilder.DropColumn(
                name: "Potassium",
                table: "user_serum_kidney");

            migrationBuilder.DropColumn(
                name: "Basophilis",
                table: "user_serum_immune_regulation");

            migrationBuilder.DropColumn(
                name: "BasophilisPercent",
                table: "user_serum_immune_regulation");

            migrationBuilder.DropColumn(
                name: "Eosinophilis",
                table: "user_serum_immune_regulation");

            migrationBuilder.DropColumn(
                name: "EosinophilisPercent",
                table: "user_serum_immune_regulation");

            migrationBuilder.DropColumn(
                name: "HsCRP",
                table: "user_serum_immune_regulation");

            migrationBuilder.DropColumn(
                name: "Lymphocytes",
                table: "user_serum_immune_regulation");

            migrationBuilder.DropColumn(
                name: "LymphocytesPercent",
                table: "user_serum_immune_regulation");

            migrationBuilder.DropColumn(
                name: "Monocytes",
                table: "user_serum_immune_regulation");

            migrationBuilder.DropColumn(
                name: "MonocytesPercent",
                table: "user_serum_immune_regulation");

            migrationBuilder.DropColumn(
                name: "Neutrophilis",
                table: "user_serum_immune_regulation");

            migrationBuilder.DropColumn(
                name: "NeutrophilisPercent",
                table: "user_serum_immune_regulation");

            migrationBuilder.DropColumn(
                name: "HDLCholesterol",
                table: "user_serum_heart");

            migrationBuilder.DropColumn(
                name: "HDLLarge",
                table: "user_serum_heart");

            migrationBuilder.DropColumn(
                name: "HsCRP",
                table: "user_serum_heart");

            migrationBuilder.DropColumn(
                name: "LDLCholesterol",
                table: "user_serum_heart");

            migrationBuilder.DropColumn(
                name: "LDLMedium",
                table: "user_serum_heart");

            migrationBuilder.DropColumn(
                name: "LDLParticleNumber",
                table: "user_serum_heart");

            migrationBuilder.DropColumn(
                name: "LDLPattern",
                table: "user_serum_heart");

            migrationBuilder.DropColumn(
                name: "LDLPeakSize",
                table: "user_serum_heart");

            migrationBuilder.DropColumn(
                name: "LDLSmall",
                table: "user_serum_heart");

            migrationBuilder.DropColumn(
                name: "LipoproteinA",
                table: "user_serum_heart");

            migrationBuilder.DropColumn(
                name: "NonHDLCholesterol",
                table: "user_serum_heart");

            migrationBuilder.DropColumn(
                name: "TotalCholesterol",
                table: "user_serum_heart");

            migrationBuilder.DropColumn(
                name: "TotalCholesterolHDL",
                table: "user_serum_heart");

            migrationBuilder.DropColumn(
                name: "Calcium",
                table: "user_serum_electolytes");

            migrationBuilder.DropColumn(
                name: "CarbonDioxide",
                table: "user_serum_electolytes");

            migrationBuilder.DropColumn(
                name: "Chloride",
                table: "user_serum_electolytes");

            migrationBuilder.DropColumn(
                name: "Magnesium",
                table: "user_serum_electolytes");

            migrationBuilder.DropColumn(
                name: "Potassium",
                table: "user_serum_electolytes");

            migrationBuilder.DropColumn(
                name: "Hematocrit",
                table: "user_serum_blood");

            migrationBuilder.DropColumn(
                name: "Hemoglobin",
                table: "user_serum_blood");

            migrationBuilder.DropColumn(
                name: "MCH",
                table: "user_serum_blood");

            migrationBuilder.DropColumn(
                name: "MCHC",
                table: "user_serum_blood");

            migrationBuilder.DropColumn(
                name: "MCV",
                table: "user_serum_blood");

            migrationBuilder.DropColumn(
                name: "MPV",
                table: "user_serum_blood");

            migrationBuilder.DropColumn(
                name: "PlateletCount",
                table: "user_serum_blood");

            migrationBuilder.DropColumn(
                name: "RBCCount",
                table: "user_serum_blood");

            migrationBuilder.RenameColumn(
                name: "TgAb",
                table: "user_serum_thyroid",
                newName: "Homocysteine");

            migrationBuilder.RenameColumn(
                name: "UricAcid",
                table: "user_serum_metabolic",
                newName: "Homocysteine");

            migrationBuilder.RenameColumn(
                name: "TotalTestosterone",
                table: "user_serum_male_health",
                newName: "Homocysteine");

            migrationBuilder.RenameColumn(
                name: "Protein",
                table: "user_serum_liver",
                newName: "Homocysteine");

            migrationBuilder.RenameColumn(
                name: "Sodium",
                table: "user_serum_kidney",
                newName: "Homocysteine");

            migrationBuilder.RenameColumn(
                name: "WBCCount",
                table: "user_serum_immune_regulation",
                newName: "Homocysteine");

            migrationBuilder.RenameColumn(
                name: "Triglycerides",
                table: "user_serum_heart",
                newName: "Homocysteine");

            migrationBuilder.RenameColumn(
                name: "Sodium",
                table: "user_serum_electolytes",
                newName: "Homocysteine");

            migrationBuilder.RenameColumn(
                name: "RDW",
                table: "user_serum_blood",
                newName: "Homocysteine");

            migrationBuilder.AddColumn<int>(
                name: "VitaminA",
                table: "user_serum_thyroid",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VitaminA",
                table: "user_serum_nutrients",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VitaminA",
                table: "user_serum_metabolic",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VitaminA",
                table: "user_serum_male_health",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VitaminA",
                table: "user_serum_liver",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VitaminA",
                table: "user_serum_kidney",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VitaminA",
                table: "user_serum_immune_regulation",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VitaminA",
                table: "user_serum_heart",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VitaminA",
                table: "user_serum_electolytes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VitaminA",
                table: "user_serum_blood",
                type: "integer",
                nullable: true);
        }
    }
}
