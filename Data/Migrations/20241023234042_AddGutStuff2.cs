using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGutStuff2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "user_gut_fungi",
                oldComment: "User variation weight log");

            migrationBuilder.AlterColumn<double>(
                name: "TotalFungi",
                table: "user_gut_fungi",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "user_gut_fungi",
                comment: "User variation weight log");

            migrationBuilder.AlterColumn<int>(
                name: "TotalFungi",
                table: "user_gut_fungi",
                type: "integer",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);
        }
    }
}
