using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations35 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mood",
                table: "user_symptom");

            migrationBuilder.DropColumn(
                name: "Mood",
                table: "user_medicine");

            migrationBuilder.DropColumn(
                name: "Mood",
                table: "user_factor");

            migrationBuilder.DropColumn(
                name: "Mood",
                table: "user_emotion");

            migrationBuilder.DropColumn(
                name: "Mood",
                table: "user_activity");

            migrationBuilder.CreateTable(
                name: "user_custom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_custom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_custom_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id");
                },
                comment: "Sage advice");

            migrationBuilder.CreateTable(
                name: "UserActivityUserCustom",
                columns: table => new
                {
                    UserActivitiesId = table.Column<int>(type: "integer", nullable: false),
                    UserCustomsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivityUserCustom", x => new { x.UserActivitiesId, x.UserCustomsId });
                    table.ForeignKey(
                        name: "FK_UserActivityUserCustom_user_activity_UserActivitiesId",
                        column: x => x.UserActivitiesId,
                        principalTable: "user_activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserActivityUserCustom_user_custom_UserCustomsId",
                        column: x => x.UserCustomsId,
                        principalTable: "user_custom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCustomUserEmotion",
                columns: table => new
                {
                    UserCustomsId = table.Column<int>(type: "integer", nullable: false),
                    UserEmotionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCustomUserEmotion", x => new { x.UserCustomsId, x.UserEmotionsId });
                    table.ForeignKey(
                        name: "FK_UserCustomUserEmotion_user_custom_UserCustomsId",
                        column: x => x.UserCustomsId,
                        principalTable: "user_custom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCustomUserEmotion_user_emotion_UserEmotionsId",
                        column: x => x.UserEmotionsId,
                        principalTable: "user_emotion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "UserCustomUserMedicine",
                columns: table => new
                {
                    UserCustomsId = table.Column<int>(type: "integer", nullable: false),
                    UserMedicinesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCustomUserMedicine", x => new { x.UserCustomsId, x.UserMedicinesId });
                    table.ForeignKey(
                        name: "FK_UserCustomUserMedicine_user_custom_UserCustomsId",
                        column: x => x.UserCustomsId,
                        principalTable: "user_custom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCustomUserMedicine_user_medicine_UserMedicinesId",
                        column: x => x.UserMedicinesId,
                        principalTable: "user_medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCustomUserSleep",
                columns: table => new
                {
                    UserCustomsId = table.Column<int>(type: "integer", nullable: false),
                    UserSleepsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCustomUserSleep", x => new { x.UserCustomsId, x.UserSleepsId });
                    table.ForeignKey(
                        name: "FK_UserCustomUserSleep_user_custom_UserCustomsId",
                        column: x => x.UserCustomsId,
                        principalTable: "user_custom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCustomUserSleep_user_sleep_UserSleepsId",
                        column: x => x.UserSleepsId,
                        principalTable: "user_sleep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCustomUserSymptom",
                columns: table => new
                {
                    UserCustomsId = table.Column<int>(type: "integer", nullable: false),
                    UserSymptomsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCustomUserSymptom", x => new { x.UserCustomsId, x.UserSymptomsId });
                    table.ForeignKey(
                        name: "FK_UserCustomUserSymptom_user_custom_UserCustomsId",
                        column: x => x.UserCustomsId,
                        principalTable: "user_custom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCustomUserSymptom_user_symptom_UserSymptomsId",
                        column: x => x.UserSymptomsId,
                        principalTable: "user_symptom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_custom_UserId",
                table: "user_custom",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivityUserCustom_UserCustomsId",
                table: "UserActivityUserCustom",
                column: "UserCustomsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomUserEmotion_UserEmotionsId",
                table: "UserCustomUserEmotion",
                column: "UserEmotionsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomUserFactor_UserFactorsId",
                table: "UserCustomUserFactor",
                column: "UserFactorsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomUserMedicine_UserMedicinesId",
                table: "UserCustomUserMedicine",
                column: "UserMedicinesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomUserSleep_UserSleepsId",
                table: "UserCustomUserSleep",
                column: "UserSleepsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomUserSymptom_UserSymptomsId",
                table: "UserCustomUserSymptom",
                column: "UserSymptomsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserActivityUserCustom");

            migrationBuilder.DropTable(
                name: "UserCustomUserEmotion");

            migrationBuilder.DropTable(
                name: "UserCustomUserFactor");

            migrationBuilder.DropTable(
                name: "UserCustomUserMedicine");

            migrationBuilder.DropTable(
                name: "UserCustomUserSleep");

            migrationBuilder.DropTable(
                name: "UserCustomUserSymptom");

            migrationBuilder.DropTable(
                name: "user_custom");

            migrationBuilder.AddColumn<int>(
                name: "Mood",
                table: "user_symptom",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mood",
                table: "user_medicine",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mood",
                table: "user_factor",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mood",
                table: "user_emotion",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mood",
                table: "user_activity",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
