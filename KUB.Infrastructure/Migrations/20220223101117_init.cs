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
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
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
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { new Guid("5d450b14-e04d-4bda-9dd5-de7cc4d77a79"), "Направляющие на переговоры" },
                    { new Guid("817bb351-7318-45a4-9460-434c9d3c9c97"), "Направляющие на переговоры" },
                    { new Guid("c8f63b05-8629-49ac-841c-081486e865ad"), "Нанимающиеся на работу" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "City" },
                values: new object[] { new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), "Пушкина 1", "Томск" });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "BlitzGameRank", "CanBeAJury", "ClassicGameRank", "DateOfBirth", "Name", "Patronym", "Surname" },
                values: new object[] { new Guid("b07d5ba0-bdea-4232-a25c-d5168eb6ea8c"), 1, true, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иван", "Иванович", "Иванов" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("08cbe5b1-bd3e-415e-b91e-e880a770655e"), "Зритель" },
                    { new Guid("1801bd8f-eeaf-459b-b09c-67a222704784"), "Судья" },
                    { new Guid("1b159fe3-c44f-4d8c-ab9c-672e870f50f6"), "Секретарь" },
                    { new Guid("8bcbf89d-e29e-43e8-9a66-4ba5d2095ff8"), "Арбитр" },
                    { new Guid("a25815e0-b2e8-475f-9161-1615a5fc05c5"), "Тренер" },
                    { new Guid("c587d294-d1fa-44de-ba28-5abfb7426d5b"), "Игрок" },
                    { new Guid("c88f6362-3f09-407e-9258-cb159976a2d9"), "Не выбрана" },
                    { new Guid("d7a15620-714d-419c-a5ba-6dea98667d03"), "Секундант" }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "SchoolName" },
                values: new object[] { new Guid("ef64f1c6-e7a5-4ecf-9c0c-a09d7587ef34"), "Нет школы" });

            migrationBuilder.InsertData(
                table: "TournamentFormats",
                columns: new[] { "Id", "Format" },
                values: new object[,]
                {
                    { new Guid("a1547ce1-ae7b-4b52-b9a4-8a237cc83ef7"), "Онлайн" },
                    { new Guid("b2d8d691-951b-47f1-a7bc-cfad2fc6e3f8"), "Гибридный" },
                    { new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), "Оффлайн" }
                });

            migrationBuilder.InsertData(
                table: "TournamentGridTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("2b46fa18-d505-458f-9392-04987392c893"), "Навылет" },
                    { new Guid("3bc25419-2769-4e77-b838-3f8c74160800"), "Каждый с каждым" },
                    { new Guid("9ea90e37-e855-4f92-b727-5ea5348c98ca"), "Комбинированный" },
                    { new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "По командам" }
                });

            migrationBuilder.InsertData(
                table: "TournamentTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("07f54603-3093-45b9-94bb-4d5322636861"), "Именной" },
                    { new Guid("1fbc32ae-010a-4199-9c2b-549fc182aed4"), "Товарищеский" },
                    { new Guid("263d3dd2-c4b3-4156-a17d-bfd32dcae3ab"), "Отборочный" },
                    { new Guid("5d69d15e-ec6c-4319-923b-e0c8af37b358"), "Финал года" },
                    { new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497"), "Практикум" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Date", "EndTime", "LocationId", "Number", "StartTime", "TournamentFormatId", "TournamentGridId", "TournamentName", "TournamentTypeId" },
                values: new object[,]
                {
                    { new Guid("07f0d44d-890c-44b2-bf59-8b0a6caac912"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 15, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске15", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("0e47e4d1-6b60-45b5-810f-4c50839ef0bf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 10, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске10", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("0e5c6a6d-7c40-454d-8c00-35b4350d206c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 17, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске17", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("0e855da7-a2e5-46e8-8378-5622a59a15d0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 0, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске0", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("15dc2a6b-fb35-41b8-8cbf-d98252643e29"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 20, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске20", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("24d2d9e0-4319-4c88-956f-e6b9da41fa09"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 28, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске28", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("36cdce96-fb14-4f93-820b-f5031dfcad79"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 29, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске29", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("3992536b-e6ce-4c28-842f-4b9bbc003275"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 1, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске1", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("3a09d495-b23b-4e98-a302-0fd00d69f388"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 18, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске18", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("47f41cdf-882a-4255-b587-4d70963ed041"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 11, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске11", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("48c9dfef-4bec-4163-aeaa-b028c085e2a1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 8, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске8", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("4a524976-78d0-4b02-b664-dfe2c8ca84d1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 13, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске13", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("4d62af2a-0252-4e20-b95e-8de83a5ec8bd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 27, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске27", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("6223273a-b7b3-460c-a3a6-2f530bf0b423"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 21, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске21", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("6343a498-7143-479a-9659-5ac61f41d27a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 6, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске6", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("63d7e7ad-a2d3-43df-99e4-1d5a4f249b71"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 4, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске4", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("646df05a-b45a-4d23-a3a2-bc204c793c93"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 23, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске23", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("747d2c65-89bc-4e67-93ce-0704a7eac4cd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 14, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске14", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("79002589-2f99-4458-99e8-1862c2c93b93"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 19, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске19", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("99618622-de9c-40ed-969b-9b17e328972a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 26, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске26", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("9eaf6eb7-42d9-4a96-b430-a7c8e2b56758"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 9, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске9", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("a2055e1d-fc20-41a2-8286-bd894a465c63"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 2, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске2", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("b4883514-8c03-4d22-a8a0-f173fe612845"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 25, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске25", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("c162548f-ec4e-466d-822f-04a675c8caa2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 22, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске22", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("c423fad4-a032-4b67-8c3e-787da632f7e3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 24, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске24", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("cf0b7407-f977-4415-a530-675ee9dd423b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 5, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске5", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("e0095e88-0c51-4d0b-988e-ba6362ddaad8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 16, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске16", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("eae717ca-b041-4ac6-a230-831618d7cc5d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 3, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске3", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("edcf451e-ff2e-42af-9916-0a11e7751bc4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 12, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске12", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") },
                    { new Guid("f6a0effc-f446-40a9-9f09-d76f7217110c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("dd63af0d-c18d-49a5-bc2e-15189663ea78"), 7, new TimeSpan(0, 0, 0, 0, 0), new Guid("b6f26c86-e0e2-4018-8d75-503cd7ba960f"), new Guid("f6e04f2b-626c-4830-a19c-b6d943e8bc58"), "Турнир в Томске7", new Guid("e955afbf-a618-4ce4-9c3d-3815d4964497") }
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
