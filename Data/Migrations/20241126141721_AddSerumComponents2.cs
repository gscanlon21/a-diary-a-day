using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSerumComponents2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Homocysteine",
                table: "user_serum_stress");

            migrationBuilder.RenameColumn(
                name: "VitaminA",
                table: "user_serum_stress",
                newName: "DHEASulfate");

            migrationBuilder.RenameColumn(
                name: "VitaminA",
                table: "user_serum_pancreas",
                newName: "Amylase");

            migrationBuilder.RenameColumn(
                name: "Homocysteine",
                table: "user_serum_pancreas",
                newName: "Lipase");

            migrationBuilder.RenameColumn(
                name: "VitaminA",
                table: "user_serum_heavy_metals",
                newName: "Lead");

            migrationBuilder.RenameColumn(
                name: "Homocysteine",
                table: "user_serum_heavy_metals",
                newName: "Mercury");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DHEASulfate",
                table: "user_serum_stress",
                newName: "VitaminA");

            migrationBuilder.RenameColumn(
                name: "Lipase",
                table: "user_serum_pancreas",
                newName: "Homocysteine");

            migrationBuilder.RenameColumn(
                name: "Amylase",
                table: "user_serum_pancreas",
                newName: "VitaminA");

            migrationBuilder.RenameColumn(
                name: "Mercury",
                table: "user_serum_heavy_metals",
                newName: "Homocysteine");

            migrationBuilder.RenameColumn(
                name: "Lead",
                table: "user_serum_heavy_metals",
                newName: "VitaminA");

            migrationBuilder.AddColumn<double>(
                name: "Homocysteine",
                table: "user_serum_stress",
                type: "double precision",
                nullable: true);
        }
    }
}
