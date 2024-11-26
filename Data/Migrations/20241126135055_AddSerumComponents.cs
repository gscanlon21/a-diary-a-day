using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSerumComponents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_serum_autoimmunity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    AntinuclearAntibodies = table.Column<double>(type: "double precision", nullable: true),
                    RheumatoidFactor = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_serum_autoimmunity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_serum_autoimmunity_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_serum_blood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    VitaminA = table.Column<int>(type: "integer", nullable: true),
                    Homocysteine = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_serum_blood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_serum_blood_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_serum_electolytes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    VitaminA = table.Column<int>(type: "integer", nullable: true),
                    Homocysteine = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_serum_electolytes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_serum_electolytes_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_serum_female_health",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    VitaminA = table.Column<int>(type: "integer", nullable: true),
                    Homocysteine = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_serum_female_health", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_serum_female_health_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_serum_heart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    VitaminA = table.Column<int>(type: "integer", nullable: true),
                    Homocysteine = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_serum_heart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_serum_heart_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_serum_heavy_metals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    VitaminA = table.Column<int>(type: "integer", nullable: true),
                    Homocysteine = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_serum_heavy_metals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_serum_heavy_metals_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_serum_immune_regulation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    VitaminA = table.Column<int>(type: "integer", nullable: true),
                    Homocysteine = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_serum_immune_regulation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_serum_immune_regulation_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_serum_kidney",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    VitaminA = table.Column<int>(type: "integer", nullable: true),
                    Homocysteine = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_serum_kidney", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_serum_kidney_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_serum_liver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    VitaminA = table.Column<int>(type: "integer", nullable: true),
                    Homocysteine = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_serum_liver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_serum_liver_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_serum_male_health",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    VitaminA = table.Column<int>(type: "integer", nullable: true),
                    Homocysteine = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_serum_male_health", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_serum_male_health_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_serum_metabolic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    VitaminA = table.Column<int>(type: "integer", nullable: true),
                    Homocysteine = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_serum_metabolic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_serum_metabolic_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_serum_nutrients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    VitaminA = table.Column<int>(type: "integer", nullable: true),
                    Homocysteine = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_serum_nutrients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_serum_nutrients_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_serum_pancreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    VitaminA = table.Column<int>(type: "integer", nullable: true),
                    Homocysteine = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_serum_pancreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_serum_pancreas_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_serum_stress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    VitaminA = table.Column<int>(type: "integer", nullable: true),
                    Homocysteine = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_serum_stress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_serum_stress_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_serum_thyroid",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    VitaminA = table.Column<int>(type: "integer", nullable: true),
                    Homocysteine = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_serum_thyroid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_serum_thyroid_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_urine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    VitaminA = table.Column<int>(type: "integer", nullable: true),
                    Homocysteine = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_urine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_urine_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_serum_autoimmunity_UserId",
                table: "user_serum_autoimmunity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_serum_blood_UserId",
                table: "user_serum_blood",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_serum_electolytes_UserId",
                table: "user_serum_electolytes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_serum_female_health_UserId",
                table: "user_serum_female_health",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_serum_heart_UserId",
                table: "user_serum_heart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_serum_heavy_metals_UserId",
                table: "user_serum_heavy_metals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_serum_immune_regulation_UserId",
                table: "user_serum_immune_regulation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_serum_kidney_UserId",
                table: "user_serum_kidney",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_serum_liver_UserId",
                table: "user_serum_liver",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_serum_male_health_UserId",
                table: "user_serum_male_health",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_serum_metabolic_UserId",
                table: "user_serum_metabolic",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_serum_nutrients_UserId",
                table: "user_serum_nutrients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_serum_pancreas_UserId",
                table: "user_serum_pancreas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_serum_stress_UserId",
                table: "user_serum_stress",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_serum_thyroid_UserId",
                table: "user_serum_thyroid",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_urine_UserId",
                table: "user_urine",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_serum_autoimmunity");

            migrationBuilder.DropTable(
                name: "user_serum_blood");

            migrationBuilder.DropTable(
                name: "user_serum_electolytes");

            migrationBuilder.DropTable(
                name: "user_serum_female_health");

            migrationBuilder.DropTable(
                name: "user_serum_heart");

            migrationBuilder.DropTable(
                name: "user_serum_heavy_metals");

            migrationBuilder.DropTable(
                name: "user_serum_immune_regulation");

            migrationBuilder.DropTable(
                name: "user_serum_kidney");

            migrationBuilder.DropTable(
                name: "user_serum_liver");

            migrationBuilder.DropTable(
                name: "user_serum_male_health");

            migrationBuilder.DropTable(
                name: "user_serum_metabolic");

            migrationBuilder.DropTable(
                name: "user_serum_nutrients");

            migrationBuilder.DropTable(
                name: "user_serum_pancreas");

            migrationBuilder.DropTable(
                name: "user_serum_stress");

            migrationBuilder.DropTable(
                name: "user_serum_thyroid");

            migrationBuilder.DropTable(
                name: "user_urine");
        }
    }
}
