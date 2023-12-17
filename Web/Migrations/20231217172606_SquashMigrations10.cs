using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_exercise");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_exercise",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false),
                    Ignore = table.Column<bool>(type: "boolean", nullable: false),
                    LastSeen = table.Column<DateOnly>(type: "date", nullable: false),
                    LastVisible = table.Column<DateOnly>(type: "date", nullable: false),
                    Progression = table.Column<int>(type: "integer", nullable: false),
                    RefreshAfter = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_exercise", x => new { x.UserId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_user_exercise_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User's progression level of an exercise");
        }
    }
}
