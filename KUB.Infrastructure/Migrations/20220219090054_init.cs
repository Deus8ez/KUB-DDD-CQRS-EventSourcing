using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KUB.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AggregateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventData = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JuryPanels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Panel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuryPanels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronym = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassicGameRank = table.Column<int>(type: "int", nullable: true),
                    BlitzGameRank = table.Column<int>(type: "int", nullable: true),
                    CanBeAJury = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TournamentFormats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentFormats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TournamentGridTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentGridTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TournamentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantInSchools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantInSchools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantInSchools_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantInSchools_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    TournamentFormatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentGridId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournaments_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tournaments_TournamentFormats_TournamentFormatId",
                        column: x => x.TournamentFormatId,
                        principalTable: "TournamentFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tournaments_TournamentGridTypes_TournamentGridId",
                        column: x => x.TournamentGridId,
                        principalTable: "TournamentGridTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tournaments_TournamentTypes_TournamentTypeId",
                        column: x => x.TournamentTypeId,
                        principalTable: "TournamentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JuryInPanels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JuryPanelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuryInPanels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JuryInPanels_JuryPanels_JuryPanelId",
                        column: x => x.JuryPanelId,
                        principalTable: "JuryPanels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JuryInPanels_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuryInPanels_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantInTournaments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantInTournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantInTournaments_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantInTournaments_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParticipantInTournaments_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "JuryPanels",
                columns: new[] { "Id", "Panel" },
                values: new object[,]
                {
                    { new Guid("26717a46-ca91-4779-a39d-33e4c2afb695"), "Направляющие на переговоры" },
                    { new Guid("b49ef3cf-6a29-479f-9448-410e05d19c77"), "Нанимающиеся на работу" },
                    { new Guid("d19273ad-706c-4b39-98d5-73e3288186c0"), "Направляющие на переговоры" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "City" },
                values: new object[] { new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), "Пушкина 1", "Томск" });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "BlitzGameRank", "CanBeAJury", "ClassicGameRank", "DateOfBirth", "Name", "Patronym", "Surname" },
                values: new object[] { new Guid("eaa8a7c8-c737-4a27-9b69-bfafea7125c7"), 1, true, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иван", "Иванович", "Иванов" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("001b0334-a425-4140-8e17-9b008652eb40"), "Секретарь" },
                    { new Guid("0a486d58-0fa3-421a-88dd-74eaa919eae2"), "Зритель" },
                    { new Guid("3b096573-4221-443d-81ed-01d8fda18f4a"), "Игрок" },
                    { new Guid("4facc2ea-c6a9-46ab-9a29-3f6b1095afba"), "Не выбрана" },
                    { new Guid("4fddf92d-ad50-4dcb-91d6-a973aacbd0c6"), "Арбитр" },
                    { new Guid("ac85a0c7-2c2e-42c9-9065-db82c4807431"), "Судья" },
                    { new Guid("d54599dc-563d-464e-b79a-a6a02f0933e0"), "Тренер" },
                    { new Guid("efde71e8-681a-4cb6-9e6a-f0022fcfa767"), "Секундант" }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "SchoolName" },
                values: new object[] { new Guid("0aa57d55-9b6b-4302-82e0-2d87f7005d51"), "Нет школы" });

            migrationBuilder.InsertData(
                table: "TournamentFormats",
                columns: new[] { "Id", "Format" },
                values: new object[,]
                {
                    { new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), "Оффлайн" },
                    { new Guid("6941a28c-bd39-498d-b6ad-4bc5a0318742"), "Гибридный" },
                    { new Guid("754e78f5-0b7c-4c5e-b35b-adff8272f6b3"), "Онлайн" }
                });

            migrationBuilder.InsertData(
                table: "TournamentGridTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("6ebc97ed-c715-4e95-9a20-a7ded5286679"), "Каждый с каждым" },
                    { new Guid("95e780ba-8962-49d6-bcdc-00ed72051bb1"), "Комбинированный" },
                    { new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "По командам" },
                    { new Guid("f52a928d-cd43-4fe3-8c53-8d612320672c"), "Навылет" }
                });

            migrationBuilder.InsertData(
                table: "TournamentTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("6e212e52-b18f-4dcf-842a-244baed39407"), "Товарищеский" },
                    { new Guid("8ad3ef95-c271-4aab-9b99-04e8522ffb77"), "Именной" },
                    { new Guid("9b941928-1c2d-4a23-801d-2e73e068ad46"), "Финал года" },
                    { new Guid("dec68aa9-34b7-4a1a-bbe8-893cb24bdee0"), "Отборочный" },
                    { new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7"), "Практикум" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Date", "EndTime", "LocationId", "StartTime", "TournamentFormatId", "TournamentGridId", "TournamentName", "TournamentTypeId" },
                values: new object[,]
                {
                    { new Guid("012c737e-8808-4701-be5a-b11be6c6b2b2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске90", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("014ddfbc-aedf-4951-a5ca-7b46f5491111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске62", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("03cc5ed0-1e07-446c-baee-0249af5267e2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске4", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("041d4850-004d-4c80-9178-91bb6c20c4aa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске44", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("04cb3eb6-81d7-4956-85c9-7f8049e65c25"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске39", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("0a6475b5-e49f-4869-990f-e5819467b95d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске96", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("0f9523e5-f34a-4871-a182-70221f16bd3f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске38", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("1272dc58-c2bd-4f9f-8a57-d58040021de6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске21", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("184d5d7b-42a1-4044-8555-35c7ac34896b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске86", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("18e965ea-e778-4001-8747-bd781fc413f8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске76", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("18f40c6c-268a-4961-b28f-0cbc0a5e81f8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске58", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("19ce2d84-2d71-4eb6-a8f4-68fef5856bf3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске20", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("1aa86c58-c64c-4a26-94eb-b3afe1c21415"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске97", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("1fb08915-3d6b-4dc4-a1a2-8e10d8ff9dcd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске34", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("21dea9b9-e26e-44f2-9044-5cd22bec1367"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске9", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("2607aa46-95bc-43e4-9879-f1bd79f4fa68"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске99", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("27ab17ae-f0cf-453d-a82e-db472cf4bdf6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске94", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("2b8a00e0-8f89-4ae9-9f10-83bf49c15931"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске1", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("2b92d103-6205-49a0-8679-ba01c0ca29d3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске22", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("2dc9338b-07c7-42b9-933d-eea86a1aea67"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске47", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("2ec5399b-9447-4997-ab38-bbd90cb87b86"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске53", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("36eb6d78-d1b1-41f9-995c-7afc5bbc049a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске92", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("39444ca6-5e8a-4e30-abef-7614d6fbbca0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске87", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("3a3ebb55-9660-47e2-a945-958bd2d09d96"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске5", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("3a765916-1936-4644-9a59-cd9ebe2ff130"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске93", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("3ab6b677-1ef8-4ec4-9982-b4eee4823df4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске68", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("3b28729c-25a7-47d8-bf81-7ff81c5ca65f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске51", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("418c1846-22af-495c-b42a-9aa2863650aa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске28", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("420924f2-e0ce-4549-87ee-28982bd6d622"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске24", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("45671fb3-a648-4628-b6e4-ab787d19632f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске63", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("46003d91-237c-4954-883c-d27fd6bc733c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске56", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("4625cf18-5cd1-4152-9057-c3235c95b70a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске6", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("4b71a50d-55db-4d44-b8af-bc035d186418"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске42", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("4bbb2a69-c2f2-4460-a1dc-cdc7d0f3dfe5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске91", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("4c281627-c0cf-44d0-a03b-961aa5a1107d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске36", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("4fbbe3c1-c8a2-4559-93d3-a0070123e0b0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске66", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("53982856-ce27-4fb1-9f92-6125b1062302"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске37", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("5577823b-2a9d-46ae-b22d-bcd8f123bef9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске10", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("56d5c5cc-5b47-4f1c-82f5-809718208e11"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске25", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("5a8b4104-1803-4d83-b7f1-a3efc7f41570"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске0", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("5ab9f412-885f-455d-9c0d-7b8587d8570b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске74", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("5adac6bd-ec0b-49fb-9743-119324cf4637"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске57", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Date", "EndTime", "LocationId", "StartTime", "TournamentFormatId", "TournamentGridId", "TournamentName", "TournamentTypeId" },
                values: new object[,]
                {
                    { new Guid("5e6b9297-41cd-4162-bf84-6af0a24d2f89"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске13", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("6140813e-2d7d-4735-801e-7d71ddb63281"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске67", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("6473a297-4d3d-4196-bd08-dabe537d5a1f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске31", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("65a342bb-e236-41fe-ab22-58eddcb323b1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске41", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("6622c2c5-9b57-4139-ab29-8478db8674fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске81", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("6b76ca5a-68d6-4f3b-8801-26347e5caf65"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске26", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("6bf1bebb-064f-4b4b-b116-12f6cf523f92"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске23", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("6ea1c772-1c70-4901-8ef0-44e57459d3af"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске33", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("6f9f70ee-a747-489b-bb8d-d5b63c93159d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске70", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("71061bfb-1d16-46c8-b281-47b5db14c931"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске69", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("71ec1bf3-1820-4390-a51f-189837548355"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске35", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("77b5c61d-7cab-4cc8-9744-cc91ad834f2a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске29", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("79756309-f1e2-45c3-8908-fc3a0832ac0c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске59", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("8070e71a-72c5-4e50-9cec-bde8902d4a3f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске7", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("848670ce-0e82-470c-90d6-9884a428ed14"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске64", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("85f12823-170c-445c-a46a-cf3e5514be9d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске43", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("87705491-645f-48c1-800c-099ae1ad310b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске77", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("8c749b96-d852-4e5a-bed4-4632445f2bfe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске60", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("9cb679a5-fc58-43de-8261-a7ec6b3fee53"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске32", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("9e4168a3-5c09-4bcc-9409-d0824fbfa707"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске8", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("a242261b-59c4-44cb-8350-0809f87bb5dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске71", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("a473f1c0-8479-48ef-a556-a21c5a03a295"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске88", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("a53eafdf-5321-46a2-843c-fb4c8404a231"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске12", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("a76ec6ef-047d-4e3c-b81a-896410544f83"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске89", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("a84df3a5-6eeb-45e3-9f1f-2e35d6f10034"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске83", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("aa1ad795-ded1-44fe-9678-5138fc3e3106"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске46", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("aae003c4-50e2-44bb-8bc9-f8738f192a1a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске49", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("abfe54c6-2548-4c40-ab2c-0f38c79e6bec"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске73", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("b3535c32-66d9-4f8a-9b1e-370459cf7745"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске14", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("b85512ed-01c0-4c8a-9e5f-29f37666c166"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске2", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("b9e234e5-11bb-455c-b7f7-ab53e03a10b7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске11", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("bdd46ac0-b216-4d3c-83f2-59c6422d79d1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске3", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("c2a55209-90b1-4a5d-82f6-2b60a0fbd030"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске84", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("c4ac4569-1c8c-48b1-818c-1f860451d834"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске16", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("c65a9bca-21cd-4fdd-a863-3de32a8e233a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске54", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("c79aceab-8ff1-4eaa-a7ba-90cc9f1c4502"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске55", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("caa9dbbf-79cb-4969-9bca-b7ee1053f9a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске15", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("cb7b4a55-eb25-4015-86ae-730dc568ebfb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске30", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("cdb8e6d0-3a78-4fc5-9b9a-07776e71e69f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске80", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("ce0c148c-fccf-407d-a0d9-cf58dd219d2e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске75", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("d55dc20f-78ff-4559-8e09-46130e90616d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске45", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("d64adb34-7ebf-42bb-a574-981d31267483"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске27", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Date", "EndTime", "LocationId", "StartTime", "TournamentFormatId", "TournamentGridId", "TournamentName", "TournamentTypeId" },
                values: new object[,]
                {
                    { new Guid("d66dffe6-f677-41a0-b08a-c34097ce79af"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске17", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("d89a5338-1f86-437b-b435-9605aeb21996"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске72", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("d8c52b2b-d1f8-417c-9bf1-7be3bb3ad3f6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске48", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("db317377-a22c-49f2-afcc-a853ef90ad1b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске98", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("dcb7fa74-26d8-4b6b-a2f8-d583dda8438d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске19", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("ddc13087-180d-4c58-b131-3f10d6f93715"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске85", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("de7010e2-313c-4d28-a047-1c641f481090"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске61", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("de7db79b-4c71-4624-b1cf-86b17751f921"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске95", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("df9f0b26-cf17-4df7-abef-5958bb4007b9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске82", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("e113c306-1862-4037-8939-42783b968049"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске50", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("e3d4b4c9-c816-4b60-a258-7db8a586d442"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске78", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("e6d771e6-2779-43f1-b76a-9640266fc19a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске40", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("e8e6bc6d-3c87-4a62-bd0b-860fedae9b18"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске52", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("f911867f-6604-4db8-90b6-312ac445fea9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске65", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("f957910b-e804-4130-8828-fed559dfc8a2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске79", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") },
                    { new Guid("fadbfd35-bd6d-49d6-9a96-27e3367c126b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("432ad51f-1f3e-467e-8328-c400fb317371"), new TimeSpan(0, 0, 0, 0, 0), new Guid("2c65d7f9-f9af-4d4b-bb9e-b2e014831036"), new Guid("9ab6272c-4c67-4ccd-9064-4a6538cf6358"), "Турнир в Томске18", new Guid("fb2adbee-66f9-4949-b993-1d9468ea15b7") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JuryInPanels_JuryPanelId",
                table: "JuryInPanels",
                column: "JuryPanelId");

            migrationBuilder.CreateIndex(
                name: "IX_JuryInPanels_ParticipantId",
                table: "JuryInPanels",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_JuryInPanels_TournamentId",
                table: "JuryInPanels",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantInSchools_ParticipantId",
                table: "ParticipantInSchools",
                column: "ParticipantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantInSchools_SchoolId",
                table: "ParticipantInSchools",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantInTournaments_ParticipantId",
                table: "ParticipantInTournaments",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantInTournaments_RoleId",
                table: "ParticipantInTournaments",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantInTournaments_TournamentId",
                table: "ParticipantInTournaments",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_LocationId",
                table: "Tournaments",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TournamentFormatId",
                table: "Tournaments",
                column: "TournamentFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TournamentGridId",
                table: "Tournaments",
                column: "TournamentGridId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TournamentTypeId",
                table: "Tournaments",
                column: "TournamentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "JuryInPanels");

            migrationBuilder.DropTable(
                name: "ParticipantInSchools");

            migrationBuilder.DropTable(
                name: "ParticipantInTournaments");

            migrationBuilder.DropTable(
                name: "JuryPanels");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "TournamentFormats");

            migrationBuilder.DropTable(
                name: "TournamentGridTypes");

            migrationBuilder.DropTable(
                name: "TournamentTypes");
        }
    }
}
