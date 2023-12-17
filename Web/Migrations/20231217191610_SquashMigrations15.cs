using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeloadAfterEveryXWeeks",
                table: "user");

            migrationBuilder.DropColumn(
                name: "IncludeMobilityWorkouts",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Intensity",
                table: "user");

            migrationBuilder.DropColumn(
                name: "RefreshAccessoryEveryXWeeks",
                table: "user");

            migrationBuilder.DropColumn(
                name: "RefreshFunctionalEveryXWeeks",
                table: "user");

            migrationBuilder.DropColumn(
                name: "ShowStaticImages",
                table: "user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeloadAfterEveryXWeeks",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeMobilityWorkouts",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Intensity",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RefreshAccessoryEveryXWeeks",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RefreshFunctionalEveryXWeeks",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ShowStaticImages",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
