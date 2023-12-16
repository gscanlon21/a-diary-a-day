using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_workout_user_UserId",
                table: "user_workout");

            migrationBuilder.DropForeignKey(
                name: "FK_user_workout_variation_user_workout_UserMoodId",
                table: "user_workout_variation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_workout",
                table: "user_workout");

            migrationBuilder.RenameTable(
                name: "user_workout",
                newName: "user_mood");

            migrationBuilder.RenameIndex(
                name: "IX_user_workout_UserId",
                table: "user_mood",
                newName: "IX_user_mood_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_mood",
                table: "user_mood",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_mood_user_UserId",
                table: "user_mood",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_workout_variation_user_mood_UserMoodId",
                table: "user_workout_variation",
                column: "UserMoodId",
                principalTable: "user_mood",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_mood_user_UserId",
                table: "user_mood");

            migrationBuilder.DropForeignKey(
                name: "FK_user_workout_variation_user_mood_UserMoodId",
                table: "user_workout_variation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_mood",
                table: "user_mood");

            migrationBuilder.RenameTable(
                name: "user_mood",
                newName: "user_workout");

            migrationBuilder.RenameIndex(
                name: "IX_user_mood_UserId",
                table: "user_workout",
                newName: "IX_user_workout_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_workout",
                table: "user_workout",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_workout_user_UserId",
                table: "user_workout",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_workout_variation_user_workout_UserMoodId",
                table: "user_workout_variation",
                column: "UserMoodId",
                principalTable: "user_workout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
