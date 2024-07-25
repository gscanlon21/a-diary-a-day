using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "footnote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Note = table.Column<string>(type: "text", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_footnote", x => x.Id);
                },
                comment: "Sage advice");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    AcceptedTerms = table.Column<bool>(type: "boolean", nullable: false),
                    FootnoteType = table.Column<int>(type: "integer", nullable: false),
                    SendDays = table.Column<int>(type: "integer", nullable: false),
                    SendHour = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Verbosity = table.Column<int>(type: "integer", nullable: false),
                    LastActive = table.Column<DateOnly>(type: "date", nullable: true),
                    NewsletterDisabledReason = table.Column<string>(type: "text", nullable: true),
                    Components = table.Column<int>(type: "integer", nullable: false),
                    Features = table.Column<int>(type: "integer", nullable: false),
                    FootnoteCountTop = table.Column<int>(type: "integer", nullable: false),
                    FootnoteCountBottom = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                },
                comment: "User who signed up for the newsletter");

            migrationBuilder.CreateTable(
                name: "user_activity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_activity_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

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
                name: "user_component",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Component = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LastUpload = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_component", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_component_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Auth tokens for a user");

            migrationBuilder.CreateTable(
                name: "user_custom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
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
                name: "user_depression",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Worthless = table.Column<int>(type: "integer", nullable: true),
                    NoFuture = table.Column<int>(type: "integer", nullable: true),
                    Helpless = table.Column<int>(type: "integer", nullable: true),
                    Sad = table.Column<int>(type: "integer", nullable: true),
                    Failure = table.Column<int>(type: "integer", nullable: true),
                    Depressed = table.Column<int>(type: "integer", nullable: true),
                    Unhappy = table.Column<int>(type: "integer", nullable: true),
                    Hopeless = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_depression", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_depression_user_UserId",
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
                name: "user_email",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    SendAfter = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    SenderId = table.Column<string>(type: "text", nullable: true),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    EmailStatus = table.Column<int>(type: "integer", nullable: false),
                    SendAttempts = table.Column<int>(type: "integer", nullable: false),
                    LastError = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_email_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "A day's workout routine");

            migrationBuilder.CreateTable(
                name: "user_emotion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_emotion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_emotion_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_footnote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UserLastSeen = table.Column<DateOnly>(type: "date", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_footnote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_footnote_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Sage advice");

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
                name: "user_journal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_journal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_journal_user_UserId",
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
                name: "user_medicine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_medicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_medicine_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_mood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Mood = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_mood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_mood_user_UserId",
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
                name: "user_people",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_people", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_people_user_UserId",
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
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Flashbacks = table.Column<int>(type: "integer", nullable: true),
                    Upset = table.Column<int>(type: "integer", nullable: true),
                    Avoid = table.Column<int>(type: "integer", nullable: true),
                    StressfulEvent = table.Column<int>(type: "integer", nullable: true),
                    NegativeEmotions = table.Column<int>(type: "integer", nullable: true),
                    NoInterest = table.Column<int>(type: "integer", nullable: true),
                    Alert = table.Column<int>(type: "integer", nullable: true),
                    Startled = table.Column<int>(type: "integer", nullable: true),
                    Irritable = table.Column<int>(type: "integer", nullable: true)
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
                name: "user_sleep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    SleepDuration = table.Column<int>(type: "integer", nullable: false),
                    SleepTime = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_sleep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_sleep_user_UserId",
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

            migrationBuilder.CreateTable(
                name: "user_symptom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_symptom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_symptom_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateTable(
                name: "user_token",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_token_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Auth tokens for a user");

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
                        name: "FK_UserCustomUserPeople_user_people_UserPeoplesId",
                        column: x => x.UserPeoplesId,
                        principalTable: "user_people",
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
                name: "IX_user_Email",
                table: "user",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_activity_UserId",
                table: "user_activity",
                column: "UserId");

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
                name: "IX_user_component_UserId",
                table: "user_component",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_custom_UserId",
                table: "user_custom",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_depression_UserId",
                table: "user_depression",
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
                name: "IX_user_email_UserId",
                table: "user_email",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_emotion_UserId",
                table: "user_emotion",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_footnote_UserId",
                table: "user_footnote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_generalized_anxiety_severity_UserId",
                table: "user_generalized_anxiety_severity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_journal_UserId",
                table: "user_journal",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_mania_UserId",
                table: "user_mania",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_medicine_UserId",
                table: "user_medicine",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_mood_UserId",
                table: "user_mood",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_panic_severity_UserId",
                table: "user_panic_severity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_people_UserId",
                table: "user_people",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_posttraumatic_stress_severity_UserId",
                table: "user_posttraumatic_stress_severity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_sleep_UserId",
                table: "user_sleep",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_social_anxiety_severity_UserId",
                table: "user_social_anxiety_severity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_symptom_UserId",
                table: "user_symptom",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_token_UserId_Token",
                table: "user_token",
                columns: new[] { "UserId", "Token" });

            migrationBuilder.CreateIndex(
                name: "IX_UserActivityUserCustom_UserCustomsId",
                table: "UserActivityUserCustom",
                column: "UserCustomsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomUserEmotion_UserEmotionsId",
                table: "UserCustomUserEmotion",
                column: "UserEmotionsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomUserMedicine_UserMedicinesId",
                table: "UserCustomUserMedicine",
                column: "UserMedicinesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomUserPeople_UserPeoplesId",
                table: "UserCustomUserPeople",
                column: "UserPeoplesId");

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
                name: "footnote");

            migrationBuilder.DropTable(
                name: "user_acute_stress_severity");

            migrationBuilder.DropTable(
                name: "user_agoraphobia_severity");

            migrationBuilder.DropTable(
                name: "user_anger");

            migrationBuilder.DropTable(
                name: "user_anxiety");

            migrationBuilder.DropTable(
                name: "user_component");

            migrationBuilder.DropTable(
                name: "user_depression");

            migrationBuilder.DropTable(
                name: "user_depression_severity");

            migrationBuilder.DropTable(
                name: "user_dissociative_severity");

            migrationBuilder.DropTable(
                name: "user_email");

            migrationBuilder.DropTable(
                name: "user_footnote");

            migrationBuilder.DropTable(
                name: "user_generalized_anxiety_severity");

            migrationBuilder.DropTable(
                name: "user_journal");

            migrationBuilder.DropTable(
                name: "user_mania");

            migrationBuilder.DropTable(
                name: "user_mood");

            migrationBuilder.DropTable(
                name: "user_panic_severity");

            migrationBuilder.DropTable(
                name: "user_posttraumatic_stress_severity");

            migrationBuilder.DropTable(
                name: "user_social_anxiety_severity");

            migrationBuilder.DropTable(
                name: "user_token");

            migrationBuilder.DropTable(
                name: "UserActivityUserCustom");

            migrationBuilder.DropTable(
                name: "UserCustomUserEmotion");

            migrationBuilder.DropTable(
                name: "UserCustomUserMedicine");

            migrationBuilder.DropTable(
                name: "UserCustomUserPeople");

            migrationBuilder.DropTable(
                name: "UserCustomUserSleep");

            migrationBuilder.DropTable(
                name: "UserCustomUserSymptom");

            migrationBuilder.DropTable(
                name: "user_activity");

            migrationBuilder.DropTable(
                name: "user_emotion");

            migrationBuilder.DropTable(
                name: "user_medicine");

            migrationBuilder.DropTable(
                name: "user_people");

            migrationBuilder.DropTable(
                name: "user_sleep");

            migrationBuilder.DropTable(
                name: "user_custom");

            migrationBuilder.DropTable(
                name: "user_symptom");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
