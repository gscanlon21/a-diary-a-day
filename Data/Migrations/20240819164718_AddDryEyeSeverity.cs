using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDryEyeSeverity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_dry_eyes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    DrynessFrequency = table.Column<int>(type: "integer", nullable: true),
                    SorenessFrequency = table.Column<int>(type: "integer", nullable: true),
                    BurningFrequency = table.Column<int>(type: "integer", nullable: true),
                    FatigueFrequency = table.Column<int>(type: "integer", nullable: true),
                    DrynessSeverity = table.Column<int>(type: "integer", nullable: true),
                    SorenessSeverity = table.Column<int>(type: "integer", nullable: true),
                    BurningSeverity = table.Column<int>(type: "integer", nullable: true),
                    FatigueSeverity = table.Column<int>(type: "integer", nullable: true),
                    LastExeriencedSymptoms = table.Column<int>(type: "integer", nullable: true),
                    EyeDrops = table.Column<bool>(type: "boolean", nullable: false),
                    DropsLast4Hours = table.Column<bool>(type: "boolean", nullable: false),
                    GelsLast12Hours = table.Column<bool>(type: "boolean", nullable: false),
                    DropsUsedToday = table.Column<bool>(type: "boolean", nullable: false),
                    DropDuration = table.Column<int>(type: "integer", nullable: false),
                    MoisturizerToday = table.Column<bool>(type: "boolean", nullable: false),
                    MakeupToday = table.Column<bool>(type: "boolean", nullable: false),
                    TouchedEyesToday = table.Column<bool>(type: "boolean", nullable: false),
                    VisualBlinking = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_dry_eyes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_dry_eyes_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_feast_allergens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_feast_allergens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_feast_allergens_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateIndex(
                name: "IX_user_dry_eyes_UserId",
                table: "user_dry_eyes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_feast_allergens_UserId",
                table: "user_feast_allergens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_dry_eyes");

            migrationBuilder.DropTable(
                name: "user_feast_allergens");
        }
    }
}
