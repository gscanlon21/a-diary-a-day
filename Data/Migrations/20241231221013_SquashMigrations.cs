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
                });

            migrationBuilder.CreateTable(
                name: "gene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DisabledReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gene", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "study",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: false),
                    DisabledReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_study", x => x.Id);
                });

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
                    Components = table.Column<long>(type: "bigint", nullable: false),
                    Features = table.Column<int>(type: "integer", nullable: false),
                    FeastEmail = table.Column<string>(type: "text", nullable: true),
                    FeastToken = table.Column<string>(type: "text", nullable: true),
                    FootnoteCountTop = table.Column<int>(type: "integer", nullable: false),
                    FootnoteCountBottom = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

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
                });

            migrationBuilder.CreateTable(
                name: "snp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DisabledReason = table.Column<string>(type: "text", nullable: true),
                    GeneId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_snp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_snp_gene_GeneId",
                        column: x => x.GeneId,
                        principalTable: "gene",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                });

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
                });

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
                });

            migrationBuilder.CreateTable(
                name: "user_allergens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Allergens = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_allergens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_allergens_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                });

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
                });

            migrationBuilder.CreateTable(
                name: "user_blood_pressure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    SystolicPressure = table.Column<int>(type: "integer", nullable: false),
                    DiastolicPressure = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_blood_pressure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_blood_pressure_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_blood_work",
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
                    table.PrimaryKey("PK_user_blood_work", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_blood_work_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                });

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
                    BilirubinTotal = table.Column<double>(type: "double precision", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "user_component",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Component = table.Column<long>(type: "bigint", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "user_component_setting",
                columns: table => new
                {
                    Component = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Days = table.Column<int>(type: "integer", nullable: false),
                    SubComponents = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_component_setting", x => new { x.UserId, x.Component });
                    table.ForeignKey(
                        name: "FK_user_component_setting_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                });

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
                });

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
                });

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
                });

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
                });

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
                });

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
                });

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
                });

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
                });

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
                });

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
                });

            migrationBuilder.CreateTable(
                name: "user_gut_fungi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TotalFungi = table.Column<double>(type: "double precision", nullable: true)
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
                });

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
                });

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
                });

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
                });

            migrationBuilder.CreateTable(
                name: "user_gut_pillars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Digestion = table.Column<double>(type: "double precision", nullable: true),
                    Inflammation = table.Column<double>(type: "double precision", nullable: true),
                    GutDysbiosis = table.Column<double>(type: "double precision", nullable: true),
                    IntestinalPermeability = table.Column<double>(type: "double precision", nullable: true),
                    NervousSystem = table.Column<double>(type: "double precision", nullable: true),
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
                });

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
                });

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
                });

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
                });

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
                });

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
                });

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
                });

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
                });

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
                });

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
                });

            migrationBuilder.CreateTable(
                name: "user_saliva_stress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    MorningCortisol = table.Column<double>(type: "double precision", nullable: true),
                    DaytimeCortisol = table.Column<double>(type: "double precision", nullable: true),
                    EveningCortisol = table.Column<double>(type: "double precision", nullable: true),
                    NightCortisol = table.Column<double>(type: "double precision", nullable: true),
                    DHEA = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_saliva_stress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_saliva_stress_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_serum_autoimmunity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    AntinuclearAntibodies = table.Column<int>(type: "integer", nullable: true),
                    RheumatoidFactor = table.Column<int>(type: "integer", nullable: true)
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
                    Hematocrit = table.Column<double>(type: "double precision", nullable: true),
                    Hemoglobin = table.Column<double>(type: "double precision", nullable: true),
                    MCH = table.Column<double>(type: "double precision", nullable: true),
                    MCHC = table.Column<double>(type: "double precision", nullable: true),
                    MCV = table.Column<double>(type: "double precision", nullable: true),
                    MPV = table.Column<double>(type: "double precision", nullable: true),
                    PlateletCount = table.Column<double>(type: "double precision", nullable: true),
                    RBCCount = table.Column<double>(type: "double precision", nullable: true),
                    RDW = table.Column<double>(type: "double precision", nullable: true)
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
                    Calcium = table.Column<double>(type: "double precision", nullable: true),
                    CarbonDioxide = table.Column<double>(type: "double precision", nullable: true),
                    Chloride = table.Column<double>(type: "double precision", nullable: true),
                    Magnesium = table.Column<double>(type: "double precision", nullable: true),
                    Potassium = table.Column<double>(type: "double precision", nullable: true),
                    Sodium = table.Column<double>(type: "double precision", nullable: true)
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
                    SHBG = table.Column<double>(type: "double precision", nullable: true),
                    FreePSA = table.Column<double>(type: "double precision", nullable: true),
                    DHEASulfate = table.Column<double>(type: "double precision", nullable: true),
                    E2 = table.Column<double>(type: "double precision", nullable: true),
                    FSH = table.Column<double>(type: "double precision", nullable: true),
                    LH = table.Column<double>(type: "double precision", nullable: true),
                    Prolactin = table.Column<double>(type: "double precision", nullable: true),
                    TotalPSA = table.Column<double>(type: "double precision", nullable: true),
                    FreePSAPercent = table.Column<double>(type: "double precision", nullable: true),
                    FreeTestosterone = table.Column<double>(type: "double precision", nullable: true),
                    TotalTestosterone = table.Column<double>(type: "double precision", nullable: true)
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
                    HDLLarge = table.Column<double>(type: "double precision", nullable: true),
                    LDLMedium = table.Column<double>(type: "double precision", nullable: true),
                    LDLParticleNumber = table.Column<double>(type: "double precision", nullable: true),
                    LDLPattern = table.Column<double>(type: "double precision", nullable: true),
                    LDLPeakSize = table.Column<double>(type: "double precision", nullable: true),
                    LDLSmall = table.Column<double>(type: "double precision", nullable: true),
                    LDLCholesterol = table.Column<double>(type: "double precision", nullable: true),
                    NonHDLCholesterol = table.Column<double>(type: "double precision", nullable: true),
                    HsCRP = table.Column<double>(type: "double precision", nullable: true),
                    LipoproteinA = table.Column<double>(type: "double precision", nullable: true),
                    TotalCholesterol = table.Column<double>(type: "double precision", nullable: true),
                    TotalCholesterolHDL = table.Column<double>(type: "double precision", nullable: true),
                    HDLCholesterol = table.Column<double>(type: "double precision", nullable: true),
                    Triglycerides = table.Column<double>(type: "double precision", nullable: true)
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
                    Lead = table.Column<double>(type: "double precision", nullable: true),
                    Mercury = table.Column<int>(type: "integer", nullable: true)
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
                    BasophilisPercent = table.Column<double>(type: "double precision", nullable: true),
                    EosinophilisPercent = table.Column<double>(type: "double precision", nullable: true),
                    LymphocytesPercent = table.Column<double>(type: "double precision", nullable: true),
                    MonocytesPercent = table.Column<double>(type: "double precision", nullable: true),
                    NeutrophilisPercent = table.Column<double>(type: "double precision", nullable: true),
                    Basophilis = table.Column<double>(type: "double precision", nullable: true),
                    Eosinophilis = table.Column<double>(type: "double precision", nullable: true),
                    Lymphocytes = table.Column<double>(type: "double precision", nullable: true),
                    Monocytes = table.Column<double>(type: "double precision", nullable: true),
                    Neutrophilis = table.Column<double>(type: "double precision", nullable: true),
                    HsCRP = table.Column<double>(type: "double precision", nullable: true),
                    WBCCount = table.Column<double>(type: "double precision", nullable: true)
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
                    AlbuminUrine = table.Column<double>(type: "double precision", nullable: true),
                    BUN = table.Column<double>(type: "double precision", nullable: true),
                    Calcium = table.Column<double>(type: "double precision", nullable: true),
                    Chloride = table.Column<double>(type: "double precision", nullable: true),
                    Creatinine = table.Column<double>(type: "double precision", nullable: true),
                    EGFR = table.Column<double>(type: "double precision", nullable: true),
                    Potassium = table.Column<double>(type: "double precision", nullable: true),
                    Sodium = table.Column<double>(type: "double precision", nullable: true)
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
                    ALT = table.Column<double>(type: "double precision", nullable: true),
                    Albumin = table.Column<double>(type: "double precision", nullable: true),
                    AlbuminGlobulin = table.Column<double>(type: "double precision", nullable: true),
                    ALP = table.Column<double>(type: "double precision", nullable: true),
                    AST = table.Column<double>(type: "double precision", nullable: true),
                    GGT = table.Column<double>(type: "double precision", nullable: true),
                    Globulin = table.Column<double>(type: "double precision", nullable: true),
                    Bilirubin = table.Column<double>(type: "double precision", nullable: true),
                    Protein = table.Column<double>(type: "double precision", nullable: true)
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
                    SHBG = table.Column<double>(type: "double precision", nullable: true),
                    FreePSA = table.Column<double>(type: "double precision", nullable: true),
                    DHEASulfate = table.Column<double>(type: "double precision", nullable: true),
                    E2 = table.Column<double>(type: "double precision", nullable: true),
                    FSH = table.Column<double>(type: "double precision", nullable: true),
                    LH = table.Column<double>(type: "double precision", nullable: true),
                    Prolactin = table.Column<double>(type: "double precision", nullable: true),
                    TotalPSA = table.Column<double>(type: "double precision", nullable: true),
                    FreePSAPercent = table.Column<double>(type: "double precision", nullable: true),
                    FreeTestosterone = table.Column<double>(type: "double precision", nullable: true),
                    TotalTestosterone = table.Column<double>(type: "double precision", nullable: true)
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
                    Glucose = table.Column<double>(type: "double precision", nullable: true),
                    UricAcid = table.Column<double>(type: "double precision", nullable: true),
                    HbA1c = table.Column<double>(type: "double precision", nullable: true),
                    Insulin = table.Column<double>(type: "double precision", nullable: true),
                    Leptin = table.Column<double>(type: "double precision", nullable: true)
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
                    Ferritin = table.Column<double>(type: "double precision", nullable: true),
                    Homocysteine = table.Column<double>(type: "double precision", nullable: true),
                    Calcium = table.Column<double>(type: "double precision", nullable: true),
                    Iron = table.Column<double>(type: "double precision", nullable: true),
                    IronSat = table.Column<double>(type: "double precision", nullable: true),
                    IronBindingCapacity = table.Column<double>(type: "double precision", nullable: true),
                    Magnesium = table.Column<double>(type: "double precision", nullable: true),
                    MMA = table.Column<double>(type: "double precision", nullable: true),
                    VitaminD = table.Column<double>(type: "double precision", nullable: true),
                    Zinc = table.Column<double>(type: "double precision", nullable: true)
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
                    Amylase = table.Column<int>(type: "integer", nullable: true),
                    Lipase = table.Column<int>(type: "integer", nullable: true)
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
                    DHEASulfate = table.Column<int>(type: "integer", nullable: true)
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
                    TgAb = table.Column<double>(type: "double precision", nullable: true),
                    TPO = table.Column<double>(type: "double precision", nullable: true),
                    TSH = table.Column<double>(type: "double precision", nullable: true),
                    T4 = table.Column<double>(type: "double precision", nullable: true),
                    T3 = table.Column<double>(type: "double precision", nullable: true)
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
                });

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
                });

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
                });

            migrationBuilder.CreateTable(
                name: "user_task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    InternalNotes = table.Column<string>(type: "text", nullable: true),
                    Section = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ReferenceMin = table.Column<double>(type: "double precision", nullable: true),
                    ReferenceMax = table.Column<double>(type: "double precision", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    ShowLog = table.Column<bool>(type: "boolean", nullable: false),
                    PersistUntilComplete = table.Column<bool>(type: "boolean", nullable: false),
                    LastSeen = table.Column<DateOnly>(type: "date", nullable: false),
                    LastCompleted = table.Column<DateOnly>(type: "date", nullable: false),
                    RefreshAfter = table.Column<DateOnly>(type: "date", nullable: true),
                    LastDeload = table.Column<DateOnly>(type: "date", nullable: false),
                    LagRefreshXDays = table.Column<int>(type: "integer", nullable: false),
                    PadRefreshXDays = table.Column<int>(type: "integer", nullable: false),
                    DeloadAfterXWeeks = table.Column<int>(type: "integer", nullable: false),
                    DeloadDurationWeeks = table.Column<int>(type: "integer", nullable: false),
                    DisabledReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_task_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id");
                });

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
                });

            migrationBuilder.CreateTable(
                name: "user_urine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Albumin = table.Column<double>(type: "double precision", nullable: true),
                    Bilirubin = table.Column<double>(type: "double precision", nullable: true),
                    Glucose = table.Column<double>(type: "double precision", nullable: true),
                    Ketones = table.Column<double>(type: "double precision", nullable: true),
                    Leukocyte = table.Column<double>(type: "double precision", nullable: true),
                    Nitrate = table.Column<double>(type: "double precision", nullable: true),
                    OccultBlood = table.Column<double>(type: "double precision", nullable: true),
                    Protein = table.Column<double>(type: "double precision", nullable: true),
                    SpecificGravity = table.Column<double>(type: "double precision", nullable: true),
                    PH = table.Column<double>(type: "double precision", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "study_snp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    StudyId = table.Column<int>(type: "integer", nullable: false),
                    GeneId = table.Column<int>(type: "integer", nullable: true),
                    SNPId = table.Column<int>(type: "integer", nullable: true),
                    EffectAllele = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_study_snp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_study_snp_gene_GeneId",
                        column: x => x.GeneId,
                        principalTable: "gene",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_study_snp_snp_SNPId",
                        column: x => x.SNPId,
                        principalTable: "snp",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_study_snp_study_StudyId",
                        column: x => x.StudyId,
                        principalTable: "study",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "study_supplement",
                columns: table => new
                {
                    StudyId = table.Column<int>(type: "integer", nullable: false),
                    UserTaskId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_study_supplement", x => new { x.StudyId, x.UserTaskId });
                    table.ForeignKey(
                        name: "FK_study_supplement_study_StudyId",
                        column: x => x.StudyId,
                        principalTable: "study",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_study_supplement_user_task_UserTaskId",
                        column: x => x.UserTaskId,
                        principalTable: "user_task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_diary_task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserDiaryId = table.Column<int>(type: "integer", nullable: false),
                    UserTaskId = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Section = table.Column<int>(type: "integer", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "user_task_log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserTaskId = table.Column<int>(type: "integer", nullable: false),
                    Section = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Complete = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_task_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_task_log_user_task_UserTaskId",
                        column: x => x.UserTaskId,
                        principalTable: "user_task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_snp_GeneId",
                table: "snp",
                column: "GeneId");

            migrationBuilder.CreateIndex(
                name: "IX_study_snp_GeneId",
                table: "study_snp",
                column: "GeneId");

            migrationBuilder.CreateIndex(
                name: "IX_study_snp_SNPId",
                table: "study_snp",
                column: "SNPId");

            migrationBuilder.CreateIndex(
                name: "IX_study_snp_StudyId",
                table: "study_snp",
                column: "StudyId");

            migrationBuilder.CreateIndex(
                name: "IX_study_supplement_UserTaskId",
                table: "study_supplement",
                column: "UserTaskId");

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
                name: "IX_user_allergens_UserId",
                table: "user_allergens",
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
                name: "IX_user_blood_pressure_UserId",
                table: "user_blood_pressure",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_blood_work_UserId",
                table: "user_blood_work",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_cbc_w_auto_diff_UserId",
                table: "user_cbc_w_auto_diff",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_complete_metabolic_panel_UserId",
                table: "user_complete_metabolic_panel",
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
                name: "IX_user_diary_task_UserDiaryId",
                table: "user_diary_task",
                column: "UserDiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_user_diary_task_UserTaskId",
                table: "user_diary_task",
                column: "UserTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_user_dissociative_severity_UserId",
                table: "user_dissociative_severity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_dry_eyes_UserId",
                table: "user_dry_eyes",
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
                name: "IX_user_gut_bad_bacteria_UserId",
                table: "user_gut_bad_bacteria",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_gut_conditional_bacteria_UserId",
                table: "user_gut_conditional_bacteria",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_gut_fungi_UserId",
                table: "user_gut_fungi",
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
                name: "IX_user_gut_pillars_UserId",
                table: "user_gut_pillars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_gut_probiotics_UserId",
                table: "user_gut_probiotics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_gut_short_chain_fatty_acids_UserId",
                table: "user_gut_short_chain_fatty_acids",
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
                name: "IX_user_saliva_stress_UserId",
                table: "user_saliva_stress",
                column: "UserId");

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
                name: "IX_user_task_UserId",
                table: "user_task",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_task_log_UserTaskId",
                table: "user_task_log",
                column: "UserTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_user_token_UserId_Token",
                table: "user_token",
                columns: new[] { "UserId", "Token" });

            migrationBuilder.CreateIndex(
                name: "IX_user_urine_UserId",
                table: "user_urine",
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
                name: "study_snp");

            migrationBuilder.DropTable(
                name: "study_supplement");

            migrationBuilder.DropTable(
                name: "user_acute_stress_severity");

            migrationBuilder.DropTable(
                name: "user_agoraphobia_severity");

            migrationBuilder.DropTable(
                name: "user_allergens");

            migrationBuilder.DropTable(
                name: "user_anger");

            migrationBuilder.DropTable(
                name: "user_anxiety");

            migrationBuilder.DropTable(
                name: "user_blood_pressure");

            migrationBuilder.DropTable(
                name: "user_blood_work");

            migrationBuilder.DropTable(
                name: "user_cbc_w_auto_diff");

            migrationBuilder.DropTable(
                name: "user_complete_metabolic_panel");

            migrationBuilder.DropTable(
                name: "user_component");

            migrationBuilder.DropTable(
                name: "user_component_setting");

            migrationBuilder.DropTable(
                name: "user_depression");

            migrationBuilder.DropTable(
                name: "user_depression_severity");

            migrationBuilder.DropTable(
                name: "user_diary_task");

            migrationBuilder.DropTable(
                name: "user_dissociative_severity");

            migrationBuilder.DropTable(
                name: "user_dry_eyes");

            migrationBuilder.DropTable(
                name: "user_email");

            migrationBuilder.DropTable(
                name: "user_footnote");

            migrationBuilder.DropTable(
                name: "user_generalized_anxiety_severity");

            migrationBuilder.DropTable(
                name: "user_gut_bad_bacteria");

            migrationBuilder.DropTable(
                name: "user_gut_conditional_bacteria");

            migrationBuilder.DropTable(
                name: "user_gut_fungi");

            migrationBuilder.DropTable(
                name: "user_gut_good_bacteria");

            migrationBuilder.DropTable(
                name: "user_gut_micronutrients");

            migrationBuilder.DropTable(
                name: "user_gut_pathogens");

            migrationBuilder.DropTable(
                name: "user_gut_pillars");

            migrationBuilder.DropTable(
                name: "user_gut_probiotics");

            migrationBuilder.DropTable(
                name: "user_gut_short_chain_fatty_acids");

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
                name: "user_saliva_stress");

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
                name: "user_social_anxiety_severity");

            migrationBuilder.DropTable(
                name: "user_task_log");

            migrationBuilder.DropTable(
                name: "user_token");

            migrationBuilder.DropTable(
                name: "user_urine");

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
                name: "snp");

            migrationBuilder.DropTable(
                name: "study");

            migrationBuilder.DropTable(
                name: "user_diary");

            migrationBuilder.DropTable(
                name: "user_task");

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
                name: "gene");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
