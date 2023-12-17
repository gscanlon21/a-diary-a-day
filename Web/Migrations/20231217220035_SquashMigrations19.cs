using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_acute_stress_severity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Flashbacks = table.Column<int>(type: "integer", nullable: true),
                    Upset = table.Column<int>(type: "integer", nullable: true),
                    Distant = table.Column<int>(type: "integer", nullable: true),
                    Avoid = table.Column<int>(type: "integer", nullable: true),
                    Alert = table.Column<int>(type: "integer", nullable: true),
                    Startled = table.Column<int>(type: "integer", nullable: true),
                    Irritable = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_acute_stress_severity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_acute_stress_severity_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_agoraphobia_severity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Fright = table.Column<int>(type: "integer", nullable: true),
                    Nervous = table.Column<int>(type: "integer", nullable: true),
                    Panic = table.Column<int>(type: "integer", nullable: true),
                    Heart = table.Column<int>(type: "integer", nullable: true),
                    Tense = table.Column<int>(type: "integer", nullable: true),
                    Avoided = table.Column<int>(type: "integer", nullable: true),
                    LeftEarly = table.Column<int>(type: "integer", nullable: true),
                    Preparing = table.Column<int>(type: "integer", nullable: true),
                    Distracted = table.Column<int>(type: "integer", nullable: true),
                    Cope = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_agoraphobia_severity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_agoraphobia_severity_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_anger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Irritated = table.Column<int>(type: "integer", nullable: true),
                    Angry = table.Column<int>(type: "integer", nullable: true),
                    Explode = table.Column<int>(type: "integer", nullable: true),
                    Grouchy = table.Column<int>(type: "integer", nullable: true),
                    Annoyed = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_anger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_anger_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_anxiety",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Fearful = table.Column<int>(type: "integer", nullable: true),
                    Anxious = table.Column<int>(type: "integer", nullable: true),
                    Worried = table.Column<int>(type: "integer", nullable: true),
                    Focus = table.Column<int>(type: "integer", nullable: true),
                    Nervous = table.Column<int>(type: "integer", nullable: true),
                    Uneasy = table.Column<int>(type: "integer", nullable: true),
                    Tense = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_anxiety", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_anxiety_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_depression_severity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    NoInterest = table.Column<int>(type: "integer", nullable: true),
                    Hopeless = table.Column<int>(type: "integer", nullable: true),
                    Sleeping = table.Column<int>(type: "integer", nullable: true),
                    NoEnergy = table.Column<int>(type: "integer", nullable: true),
                    Eating = table.Column<int>(type: "integer", nullable: true),
                    FeelingBad = table.Column<int>(type: "integer", nullable: true),
                    NoConcentration = table.Column<int>(type: "integer", nullable: true),
                    Slowly = table.Column<int>(type: "integer", nullable: true),
                    BetterOffDead = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_depression_severity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_depression_severity_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_dissociative_severity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Nothing = table.Column<int>(type: "integer", nullable: true),
                    Unreal = table.Column<int>(type: "integer", nullable: true),
                    NoMemory = table.Column<int>(type: "integer", nullable: true),
                    TalkOutLoud = table.Column<int>(type: "integer", nullable: true),
                    Unclear = table.Column<int>(type: "integer", nullable: true),
                    IgnorePain = table.Column<int>(type: "integer", nullable: true),
                    DifferentPeople = table.Column<int>(type: "integer", nullable: true),
                    EasyWhenHard = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_dissociative_severity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_dissociative_severity_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_generalized_anxiety_severity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Fright = table.Column<int>(type: "integer", nullable: true),
                    Nervous = table.Column<int>(type: "integer", nullable: true),
                    Accidents = table.Column<int>(type: "integer", nullable: true),
                    Heart = table.Column<int>(type: "integer", nullable: true),
                    Tense = table.Column<int>(type: "integer", nullable: true),
                    Avoided = table.Column<int>(type: "integer", nullable: true),
                    LeftEarly = table.Column<int>(type: "integer", nullable: true),
                    Time = table.Column<int>(type: "integer", nullable: true),
                    Reassurance = table.Column<int>(type: "integer", nullable: true),
                    Cope = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_generalized_anxiety_severity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_generalized_anxiety_severity_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_mania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Question1 = table.Column<int>(type: "integer", nullable: true),
                    Question2 = table.Column<int>(type: "integer", nullable: true),
                    Question3 = table.Column<int>(type: "integer", nullable: true),
                    Question4 = table.Column<int>(type: "integer", nullable: true),
                    Question5 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_mania", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_mania_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_panic_severity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    SuddenTerror = table.Column<int>(type: "integer", nullable: true),
                    Nervous = table.Column<int>(type: "integer", nullable: true),
                    LosingControl = table.Column<int>(type: "integer", nullable: true),
                    Heart = table.Column<int>(type: "integer", nullable: true),
                    Tense = table.Column<int>(type: "integer", nullable: true),
                    Avoided = table.Column<int>(type: "integer", nullable: true),
                    LeftEarly = table.Column<int>(type: "integer", nullable: true),
                    Preparing = table.Column<int>(type: "integer", nullable: true),
                    DistractedMyself = table.Column<int>(type: "integer", nullable: true),
                    Cope = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_panic_severity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_panic_severity_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_posttraumatic_stress_severity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Flashbacks = table.Column<int>(type: "integer", nullable: true),
                    Upset = table.Column<int>(type: "integer", nullable: true),
                    Avoid = table.Column<int>(type: "integer", nullable: true),
                    StressfulEvent = table.Column<int>(type: "integer", nullable: true),
                    NegativeEmotions = table.Column<int>(type: "integer", nullable: true),
                    NoInterest = table.Column<int>(type: "integer", nullable: true),
                    Alert = table.Column<int>(type: "integer", nullable: true),
                    Startled = table.Column<int>(type: "integer", nullable: true),
                    Irritable = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_posttraumatic_stress_severity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_posttraumatic_stress_severity_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_social_anxiety_severity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Fright = table.Column<int>(type: "integer", nullable: true),
                    Nervous = table.Column<int>(type: "integer", nullable: true),
                    Humiliated = table.Column<int>(type: "integer", nullable: true),
                    Heart = table.Column<int>(type: "integer", nullable: true),
                    Tense = table.Column<int>(type: "integer", nullable: true),
                    Avoided = table.Column<int>(type: "integer", nullable: true),
                    LeftEarly = table.Column<int>(type: "integer", nullable: true),
                    Preparing = table.Column<int>(type: "integer", nullable: true),
                    DistractedMyself = table.Column<int>(type: "integer", nullable: true),
                    Cope = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_social_anxiety_severity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_social_anxiety_severity_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateIndex(
                name: "IX_user_acute_stress_severity_UserId",
                table: "user_acute_stress_severity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_agoraphobia_severity_UserId",
                table: "user_agoraphobia_severity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_anger_UserId",
                table: "user_anger",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_anxiety_UserId",
                table: "user_anxiety",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_depression_severity_UserId",
                table: "user_depression_severity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_dissociative_severity_UserId",
                table: "user_dissociative_severity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_generalized_anxiety_severity_UserId",
                table: "user_generalized_anxiety_severity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_mania_UserId",
                table: "user_mania",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_panic_severity_UserId",
                table: "user_panic_severity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_posttraumatic_stress_severity_UserId",
                table: "user_posttraumatic_stress_severity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_social_anxiety_severity_UserId",
                table: "user_social_anxiety_severity",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_acute_stress_severity");

            migrationBuilder.DropTable(
                name: "user_agoraphobia_severity");

            migrationBuilder.DropTable(
                name: "user_anger");

            migrationBuilder.DropTable(
                name: "user_anxiety");

            migrationBuilder.DropTable(
                name: "user_depression_severity");

            migrationBuilder.DropTable(
                name: "user_dissociative_severity");

            migrationBuilder.DropTable(
                name: "user_generalized_anxiety_severity");

            migrationBuilder.DropTable(
                name: "user_mania");

            migrationBuilder.DropTable(
                name: "user_panic_severity");

            migrationBuilder.DropTable(
                name: "user_posttraumatic_stress_severity");

            migrationBuilder.DropTable(
                name: "user_social_anxiety_severity");
        }
    }
}
