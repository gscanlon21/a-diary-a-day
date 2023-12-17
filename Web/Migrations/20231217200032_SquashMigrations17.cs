using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "user_mood",
                newName: "Mood");

            migrationBuilder.CreateTable(
                name: "user_depression",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Worthless = table.Column<int>(type: "integer", nullable: false),
                    Forward = table.Column<int>(type: "integer", nullable: false),
                    Helpless = table.Column<int>(type: "integer", nullable: false),
                    Sad = table.Column<int>(type: "integer", nullable: false),
                    Failure = table.Column<int>(type: "integer", nullable: false),
                    Depressed = table.Column<int>(type: "integer", nullable: false),
                    Unhappy = table.Column<int>(type: "integer", nullable: false),
                    Hopeless = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_depression", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_depression_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateIndex(
                name: "IX_user_depression_UserId",
                table: "user_depression",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_depression");

            migrationBuilder.RenameColumn(
                name: "Mood",
                table: "user_mood",
                newName: "Value");
        }
    }
}
