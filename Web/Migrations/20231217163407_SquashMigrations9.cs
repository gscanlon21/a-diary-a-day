using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeasonedDate",
                table: "user");

            migrationBuilder.DropColumn(
                name: "SportsFocus",
                table: "user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "SeasonedDate",
                table: "user",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SportsFocus",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
