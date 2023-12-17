using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_mood_value_user_mood_UserMoodId",
                table: "user_mood_value");

            migrationBuilder.DropTable(
                name: "user_mood");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "user_mood_value",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "UserMoodId",
                table: "user_mood_value",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_user_mood_value_UserMoodId",
                table: "user_mood_value",
                newName: "IX_user_mood_value_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_mood_value_user_UserId",
                table: "user_mood_value",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_mood_value_user_UserId",
                table: "user_mood_value");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "user_mood_value",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_mood_value",
                newName: "UserMoodId");

            migrationBuilder.RenameIndex(
                name: "IX_user_mood_value_UserId",
                table: "user_mood_value",
                newName: "IX_user_mood_value_UserMoodId");

            migrationBuilder.CreateTable(
                name: "user_mood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Intensity = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_mood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_mood_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "A day's workout routine");

            migrationBuilder.CreateIndex(
                name: "IX_user_mood_UserId",
                table: "user_mood",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_mood_value_user_mood_UserMoodId",
                table: "user_mood_value",
                column: "UserMoodId",
                principalTable: "user_mood",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
