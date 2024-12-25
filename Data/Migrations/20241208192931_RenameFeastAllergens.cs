using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameFeastAllergens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_feast_allergens_user_UserId",
                table: "user_feast_allergens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_feast_allergens",
                table: "user_feast_allergens");

            migrationBuilder.RenameTable(
                name: "user_feast_allergens",
                newName: "user_allergens");

            migrationBuilder.RenameIndex(
                name: "IX_user_feast_allergens_UserId",
                table: "user_allergens",
                newName: "IX_user_allergens_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_allergens",
                table: "user_allergens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_allergens_user_UserId",
                table: "user_allergens",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_allergens_user_UserId",
                table: "user_allergens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_allergens",
                table: "user_allergens");

            migrationBuilder.RenameTable(
                name: "user_allergens",
                newName: "user_feast_allergens");

            migrationBuilder.RenameIndex(
                name: "IX_user_allergens_UserId",
                table: "user_feast_allergens",
                newName: "IX_user_feast_allergens_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_feast_allergens",
                table: "user_feast_allergens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_feast_allergens_user_UserId",
                table: "user_feast_allergens",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
