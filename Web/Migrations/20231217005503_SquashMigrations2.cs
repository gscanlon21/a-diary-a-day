using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_exercise_recipe_ExerciseId",
                table: "user_exercise");

            migrationBuilder.DropTable(
                name: "recipe");

            migrationBuilder.DropIndex(
                name: "IX_user_exercise_ExerciseId",
                table: "user_exercise");

            migrationBuilder.DropColumn(
                name: "Rotation_Id",
                table: "user_workout");

            migrationBuilder.DropColumn(
                name: "Rotation_MovementPatterns",
                table: "user_workout");

            migrationBuilder.DropColumn(
                name: "Rotation_MuscleGroups",
                table: "user_workout");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rotation_Id",
                table: "user_workout",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rotation_MovementPatterns",
                table: "user_workout",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Rotation_MuscleGroups",
                table: "user_workout",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "recipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisabledReason = table.Column<string>(type: "text", nullable: true),
                    Groups = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe", x => x.Id);
                },
                comment: "Recipes listed on the website");

            migrationBuilder.CreateIndex(
                name: "IX_user_exercise_ExerciseId",
                table: "user_exercise",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_exercise_recipe_ExerciseId",
                table: "user_exercise",
                column: "ExerciseId",
                principalTable: "recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
