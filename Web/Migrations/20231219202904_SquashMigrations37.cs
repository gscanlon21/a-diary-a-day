using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations37 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_factor_user_UserId",
                table: "user_factor");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCustomUserPeople_user_factor_UserPeoplesId",
                table: "UserCustomUserPeople");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_factor",
                table: "user_factor");

            migrationBuilder.RenameTable(
                name: "user_factor",
                newName: "user_people");

            migrationBuilder.RenameIndex(
                name: "IX_user_factor_UserId",
                table: "user_people",
                newName: "IX_user_people_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_people",
                table: "user_people",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_people_user_UserId",
                table: "user_people",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCustomUserPeople_user_people_UserPeoplesId",
                table: "UserCustomUserPeople",
                column: "UserPeoplesId",
                principalTable: "user_people",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_people_user_UserId",
                table: "user_people");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCustomUserPeople_user_people_UserPeoplesId",
                table: "UserCustomUserPeople");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_people",
                table: "user_people");

            migrationBuilder.RenameTable(
                name: "user_people",
                newName: "user_factor");

            migrationBuilder.RenameIndex(
                name: "IX_user_people_UserId",
                table: "user_factor",
                newName: "IX_user_factor_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_factor",
                table: "user_factor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_factor_user_UserId",
                table: "user_factor",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCustomUserPeople_user_factor_UserPeoplesId",
                table: "UserCustomUserPeople",
                column: "UserPeoplesId",
                principalTable: "user_factor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
