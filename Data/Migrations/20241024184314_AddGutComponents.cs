using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGutComponents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Component",
                table: "user_component_setting",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "Component",
                table: "user_component",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "Components",
                table: "user",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "user_gut_bad_bacteria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Blautia = table.Column<double>(type: "double precision", nullable: true),
                    CitrobacterFreundii = table.Column<double>(type: "double precision", nullable: true),
                    ClostridioidesDifficile = table.Column<double>(type: "double precision", nullable: true),
                    Eggerthella = table.Column<double>(type: "double precision", nullable: true),
                    EggerthellaLenta = table.Column<double>(type: "double precision", nullable: true),
                    Enterobacteriaceae = table.Column<double>(type: "double precision", nullable: true),
                    EnterobacteriaceaeAndPseudomonas = table.Column<double>(type: "double precision", nullable: true),
                    Enterococcus = table.Column<double>(type: "double precision", nullable: true),
                    EnterococcusFaecalis = table.Column<double>(type: "double precision", nullable: true),
                    EnterococcusFaecium = table.Column<double>(type: "double precision", nullable: true),
                    EnterococcusFaecalisAndFaecium = table.Column<double>(type: "double precision", nullable: true),
                    Escherichia = table.Column<double>(type: "double precision", nullable: true),
                    EscherichiaColi = table.Column<double>(type: "double precision", nullable: true),
                    Klebsiella = table.Column<double>(type: "double precision", nullable: true),
                    RuminococcusGnavus = table.Column<double>(type: "double precision", nullable: true),
                    RuminococcusTorques = table.Column<double>(type: "double precision", nullable: true),
                    Staphylococcus = table.Column<double>(type: "double precision", nullable: true),
                    StaphylococcusAureus = table.Column<double>(type: "double precision", nullable: true),
                    StreptococcusMinusThermophilusAndSalivarius = table.Column<double>(type: "double precision", nullable: true),
                    Veillonella = table.Column<double>(type: "double precision", nullable: true),
                    YersiniaEnterocolitica = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_gut_bad_bacteria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_gut_bad_bacteria_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_gut_conditional_bacteria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Bacteroides = table.Column<double>(type: "double precision", nullable: true),
                    Lactobacillus = table.Column<double>(type: "double precision", nullable: true),
                    Methanobacteria = table.Column<double>(type: "double precision", nullable: true),
                    Oscillibacter = table.Column<double>(type: "double precision", nullable: true),
                    Prevotella = table.Column<double>(type: "double precision", nullable: true),
                    RuminococcusBromii = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_gut_conditional_bacteria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_gut_conditional_bacteria_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_gut_good_bacteria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    AkkermansiaMuciniphila = table.Column<double>(type: "double precision", nullable: true),
                    Alistipes = table.Column<double>(type: "double precision", nullable: true),
                    Bifidobacterium = table.Column<double>(type: "double precision", nullable: true),
                    Coprococcus = table.Column<double>(type: "double precision", nullable: true),
                    Eubacterium = table.Column<double>(type: "double precision", nullable: true),
                    EubacteriumRectale = table.Column<double>(type: "double precision", nullable: true),
                    FaecalibacteriumPrausnitzii = table.Column<double>(type: "double precision", nullable: true),
                    LachnospiraceaeMinusBlautia = table.Column<double>(type: "double precision", nullable: true),
                    Oscillospira = table.Column<double>(type: "double precision", nullable: true),
                    Parabacteroides = table.Column<double>(type: "double precision", nullable: true),
                    Roseburia = table.Column<double>(type: "double precision", nullable: true),
                    RuminococcusMinusRBromii = table.Column<double>(type: "double precision", nullable: true),
                    Ruminococcaceae = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_gut_good_bacteria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_gut_good_bacteria_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_gut_micronutrients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    VitaminB3 = table.Column<double>(type: "double precision", nullable: true),
                    VitaminB6 = table.Column<double>(type: "double precision", nullable: true),
                    VitaminB9 = table.Column<double>(type: "double precision", nullable: true),
                    VitaminB12 = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_gut_micronutrients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_gut_micronutrients_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_gut_pathogens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Blastocystis = table.Column<int>(type: "integer", nullable: true),
                    Campylobacter = table.Column<int>(type: "integer", nullable: true),
                    ClostridioidesDifficile = table.Column<int>(type: "integer", nullable: true),
                    Cryptosporidium = table.Column<int>(type: "integer", nullable: true),
                    DientamoebaFragilis = table.Column<int>(type: "integer", nullable: true),
                    EntamoebaHistolytica = table.Column<int>(type: "integer", nullable: true),
                    EscherichiaColiO157_H7 = table.Column<int>(type: "integer", nullable: true),
                    GiardiaIntestinalis = table.Column<int>(type: "integer", nullable: true),
                    HelicobacterPylori = table.Column<int>(type: "integer", nullable: true),
                    SalmonellaEnterica = table.Column<int>(type: "integer", nullable: true),
                    VibrioCholerae = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_gut_pathogens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_gut_pathogens_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_gut_probiotics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    BacillusCoagulans = table.Column<double>(type: "double precision", nullable: true),
                    BifidobacteriumAnimalisSubspAnimalis = table.Column<double>(type: "double precision", nullable: true),
                    BifidobacteriumAnimalisSubspLactis = table.Column<double>(type: "double precision", nullable: true),
                    BifidobacteriumBifidum = table.Column<double>(type: "double precision", nullable: true),
                    BifidobacteriumBreve = table.Column<double>(type: "double precision", nullable: true),
                    BifidobacteriumLongumSubspInfantis = table.Column<double>(type: "double precision", nullable: true),
                    BifidobacteriumLongumSubspLongum = table.Column<double>(type: "double precision", nullable: true),
                    LactobacillusAcidophilus = table.Column<double>(type: "double precision", nullable: true),
                    LactobacillusBrevis = table.Column<double>(type: "double precision", nullable: true),
                    LactobacillusCasei = table.Column<double>(type: "double precision", nullable: true),
                    LactobacillusDelbrueckiiSubspBulgaricus = table.Column<double>(type: "double precision", nullable: true),
                    LactobacillusDelbrueckiiSubspDelbrueckii = table.Column<double>(type: "double precision", nullable: true),
                    LactobacillusFermentum = table.Column<double>(type: "double precision", nullable: true),
                    LactobacillusGasseri = table.Column<double>(type: "double precision", nullable: true),
                    LactobacillusHelveticus = table.Column<double>(type: "double precision", nullable: true),
                    LactobacillusParacasei = table.Column<double>(type: "double precision", nullable: true),
                    LactobacillusPlantarum = table.Column<double>(type: "double precision", nullable: true),
                    LactobacillusReuteri = table.Column<double>(type: "double precision", nullable: true),
                    LactobacillusRhamnosus = table.Column<double>(type: "double precision", nullable: true),
                    LactobacillusSalivarius = table.Column<double>(type: "double precision", nullable: true),
                    LactococcusLactis = table.Column<double>(type: "double precision", nullable: true),
                    PropionibacteriumFreudenreichii = table.Column<double>(type: "double precision", nullable: true),
                    StreptococcusSalivarius = table.Column<double>(type: "double precision", nullable: true),
                    StreptococcusThermophilus = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_gut_probiotics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_gut_probiotics_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_gut_short_chain_fatty_acids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Butyrate = table.Column<double>(type: "double precision", nullable: true),
                    Lactate = table.Column<double>(type: "double precision", nullable: true),
                    Propionate = table.Column<double>(type: "double precision", nullable: true),
                    Valerate = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_gut_short_chain_fatty_acids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_gut_short_chain_fatty_acids_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateIndex(
                name: "IX_user_gut_bad_bacteria_UserId",
                table: "user_gut_bad_bacteria",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_gut_conditional_bacteria_UserId",
                table: "user_gut_conditional_bacteria",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_gut_good_bacteria_UserId",
                table: "user_gut_good_bacteria",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_gut_micronutrients_UserId",
                table: "user_gut_micronutrients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_gut_pathogens_UserId",
                table: "user_gut_pathogens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_gut_probiotics_UserId",
                table: "user_gut_probiotics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_gut_short_chain_fatty_acids_UserId",
                table: "user_gut_short_chain_fatty_acids",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_gut_bad_bacteria");

            migrationBuilder.DropTable(
                name: "user_gut_conditional_bacteria");

            migrationBuilder.DropTable(
                name: "user_gut_good_bacteria");

            migrationBuilder.DropTable(
                name: "user_gut_micronutrients");

            migrationBuilder.DropTable(
                name: "user_gut_pathogens");

            migrationBuilder.DropTable(
                name: "user_gut_probiotics");

            migrationBuilder.DropTable(
                name: "user_gut_short_chain_fatty_acids");

            migrationBuilder.AlterColumn<int>(
                name: "Component",
                table: "user_component_setting",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Component",
                table: "user_component",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Components",
                table: "user",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
