using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_diary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Logs = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_diary", x => x.Id);
                },
                comment: "A day's workout routine");

            migrationBuilder.CreateTable(
                name: "user_task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    LastSeen = table.Column<DateOnly>(type: "date", nullable: false),
                    RefreshAfter = table.Column<DateOnly>(type: "date", nullable: true),
                    LagRefreshXWeeks = table.Column<int>(type: "integer", nullable: false),
                    PadRefreshXWeeks = table.Column<int>(type: "integer", nullable: false),
                    DisabledReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_task_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tasks listed on the website");

            migrationBuilder.CreateTable(
                name: "user_diary_task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserMoodId = table.Column<int>(type: "integer", nullable: false),
                    UserTaskId = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Section = table.Column<int>(type: "integer", nullable: false),
                    UserDiaryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_diary_task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_diary_task_user_diary_UserDiaryId",
                        column: x => x.UserDiaryId,
                        principalTable: "user_diary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_diary_task_user_task_UserTaskId",
                        column: x => x.UserTaskId,
                        principalTable: "user_task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "A day's workout routine");

            migrationBuilder.CreateIndex(
                name: "IX_user_diary_task_UserDiaryId",
                table: "user_diary_task",
                column: "UserDiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_user_diary_task_UserTaskId",
                table: "user_diary_task",
                column: "UserTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_user_task_UserId",
                table: "user_task",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_diary_task");

            migrationBuilder.DropTable(
                name: "user_diary");

            migrationBuilder.DropTable(
                name: "user_task");
        }
    }
}
