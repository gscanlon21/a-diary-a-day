using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_mood_value_user_UserId",
                table: "user_mood_value");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_mood_value",
                table: "user_mood_value");

            migrationBuilder.RenameTable(
                name: "user_mood_value",
                newName: "user_mood");

            migrationBuilder.RenameIndex(
                name: "IX_user_mood_value_UserId",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_mood_user_UserId",
                table: "user_mood");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_mood",
                table: "user_mood");

            migrationBuilder.RenameTable(
                name: "user_mood",
                newName: "user_mood_value");

            migrationBuilder.RenameIndex(
                name: "IX_user_mood_UserId",
                table: "user_mood_value",
                newName: "IX_user_mood_value_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_mood_value",
                table: "user_mood_value",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_mood_value_user_UserId",
                table: "user_mood_value",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
