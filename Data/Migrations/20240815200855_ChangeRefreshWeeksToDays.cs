using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRefreshWeeksToDays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PadRefreshXWeeks",
                table: "user_task",
                newName: "PadRefreshXDays");

            migrationBuilder.RenameColumn(
                name: "LagRefreshXWeeks",
                table: "user_task",
                newName: "LagRefreshXDays");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PadRefreshXDays",
                table: "user_task",
                newName: "PadRefreshXWeeks");

            migrationBuilder.RenameColumn(
                name: "LagRefreshXDays",
                table: "user_task",
                newName: "LagRefreshXWeeks");
        }
    }
}
