using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "user_social_anxiety_severity");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "user_posttraumatic_stress_severity");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "user_panic_severity");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "user_mania");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "user_generalized_anxiety_severity");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "user_dissociative_severity");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "user_depression_severity");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "user_depression");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "user_anxiety");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "user_anger");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "user_agoraphobia_severity");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "user_acute_stress_severity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "user_social_anxiety_severity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "user_posttraumatic_stress_severity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "user_panic_severity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "user_mania",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "user_generalized_anxiety_severity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "user_dissociative_severity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "user_depression_severity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "user_depression",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "user_anxiety",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "user_anger",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "user_agoraphobia_severity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "user_acute_stress_severity",
                type: "integer",
                nullable: true);
        }
    }
}
