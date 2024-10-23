using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGutStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_gut_fungi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TotalFungi = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_gut_fungi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_gut_fungi_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_gut_pillars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Digestion = table.Column<int>(type: "integer", nullable: true),
                    Inflammation = table.Column<int>(type: "integer", nullable: true),
                    GutDysbiosis = table.Column<int>(type: "integer", nullable: true),
                    IntestinalPermeability = table.Column<int>(type: "integer", nullable: true),
                    NervousSystem = table.Column<int>(type: "integer", nullable: true),
                    DiversityScore = table.Column<int>(type: "integer", nullable: true),
                    ImmuneReadinessScore = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_gut_pillars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_gut_pillars_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateIndex(
                name: "IX_user_gut_fungi_UserId",
                table: "user_gut_fungi",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_gut_pillars_UserId",
                table: "user_gut_pillars",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_gut_fungi");

            migrationBuilder.DropTable(
                name: "user_gut_pillars");
        }
    }
}
