using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskLogTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Complete",
                table: "user_task_log",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<double>(
                name: "ReferenceMax",
                table: "user_task",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ReferenceMin",
                table: "user_task",
                type: "double precision",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceMax",
                table: "user_task");

            migrationBuilder.DropColumn(
                name: "ReferenceMin",
                table: "user_task");

            migrationBuilder.AlterColumn<int>(
                name: "Complete",
                table: "user_task_log",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
