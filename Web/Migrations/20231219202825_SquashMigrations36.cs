using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations36 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCustomUserFactor");

            migrationBuilder.CreateTable(
                name: "UserCustomUserPeople",
                columns: table => new
                {
                    UserCustomsId = table.Column<int>(type: "integer", nullable: false),
                    UserPeoplesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCustomUserPeople", x => new { x.UserCustomsId, x.UserPeoplesId });
                    table.ForeignKey(
                        name: "FK_UserCustomUserPeople_user_custom_UserCustomsId",
                        column: x => x.UserCustomsId,
                        principalTable: "user_custom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCustomUserPeople_user_factor_UserPeoplesId",
                        column: x => x.UserPeoplesId,
                        principalTable: "user_factor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomUserPeople_UserPeoplesId",
                table: "UserCustomUserPeople",
                column: "UserPeoplesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCustomUserPeople");

            migrationBuilder.CreateTable(
                name: "UserCustomUserFactor",
                columns: table => new
                {
                    UserCustomsId = table.Column<int>(type: "integer", nullable: false),
                    UserFactorsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCustomUserFactor", x => new { x.UserCustomsId, x.UserFactorsId });
                    table.ForeignKey(
                        name: "FK_UserCustomUserFactor_user_custom_UserCustomsId",
                        column: x => x.UserCustomsId,
                        principalTable: "user_custom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCustomUserFactor_user_factor_UserFactorsId",
                        column: x => x.UserFactorsId,
                        principalTable: "user_factor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomUserFactor_UserFactorsId",
                table: "UserCustomUserFactor",
                column: "UserFactorsId");
        }
    }
}
