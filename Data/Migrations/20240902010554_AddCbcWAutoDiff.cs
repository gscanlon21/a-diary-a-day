using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCbcWAutoDiff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_cbc_w_auto_diff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    WBC = table.Column<int>(type: "integer", nullable: true),
                    RBCCount = table.Column<int>(type: "integer", nullable: true),
                    Hemoglobin = table.Column<int>(type: "integer", nullable: true),
                    Hematocrit = table.Column<int>(type: "integer", nullable: true),
                    MCV = table.Column<int>(type: "integer", nullable: true),
                    MCH = table.Column<int>(type: "integer", nullable: true),
                    MCHC = table.Column<int>(type: "integer", nullable: true),
                    RDW_CV = table.Column<int>(type: "integer", nullable: true),
                    PlatletCount = table.Column<int>(type: "integer", nullable: true),
                    MPV = table.Column<int>(type: "integer", nullable: true),
                    MonocytePercent = table.Column<int>(type: "integer", nullable: true),
                    EosinophilPercent = table.Column<int>(type: "integer", nullable: true),
                    BasophilPercent = table.Column<int>(type: "integer", nullable: true),
                    ImmatureGranulocytesPercent = table.Column<int>(type: "integer", nullable: true),
                    NeutrophilAbsolute = table.Column<int>(type: "integer", nullable: true),
                    LymphocyteAbsolute = table.Column<int>(type: "integer", nullable: true),
                    MonocyteAbsolute = table.Column<int>(type: "integer", nullable: true),
                    EosinophilAbsolute = table.Column<int>(type: "integer", nullable: true),
                    BasophilAbsolute = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_cbc_w_auto_diff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_cbc_w_auto_diff_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateIndex(
                name: "IX_user_cbc_w_auto_diff_UserId",
                table: "user_cbc_w_auto_diff",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_cbc_w_auto_diff");
        }
    }
}
