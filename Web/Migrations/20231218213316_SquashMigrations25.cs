using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mood",
                table: "user_sleep",
                newName: "SleepTime");

            migrationBuilder.AddColumn<int>(
                name: "SleepDuration",
                table: "user_sleep",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SleepDuration",
                table: "user_sleep");

            migrationBuilder.RenameColumn(
                name: "SleepTime",
                table: "user_sleep",
                newName: "Mood");
        }
    }
}
