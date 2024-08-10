using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCompleteMetabolicPanel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_complete_metabolic_panel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Glucose = table.Column<int>(type: "integer", nullable: true),
                    Sodium = table.Column<int>(type: "integer", nullable: true),
                    Potassium = table.Column<int>(type: "integer", nullable: true),
                    Chloride = table.Column<int>(type: "integer", nullable: true),
                    CO2 = table.Column<int>(type: "integer", nullable: true),
                    Calcium = table.Column<int>(type: "integer", nullable: true),
                    AnionGap = table.Column<int>(type: "integer", nullable: true),
                    BUN = table.Column<int>(type: "integer", nullable: true),
                    Creatinine = table.Column<int>(type: "integer", nullable: true),
                    AlkalinePhosphatase = table.Column<int>(type: "integer", nullable: true),
                    ALT = table.Column<int>(type: "integer", nullable: true),
                    AST = table.Column<int>(type: "integer", nullable: true),
                    ProteinTotal = table.Column<int>(type: "integer", nullable: true),
                    Albumin = table.Column<int>(type: "integer", nullable: true),
                    BilirubinTotal = table.Column<int>(type: "integer", nullable: true),
                    EGFRbyCKDEPI = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_complete_metabolic_panel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_complete_metabolic_panel_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateIndex(
                name: "IX_user_complete_metabolic_panel_UserId",
                table: "user_complete_metabolic_panel",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_complete_metabolic_panel");
        }
    }
}
