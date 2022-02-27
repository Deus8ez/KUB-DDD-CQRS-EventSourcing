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
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
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
                    { new Guid("09b5071a-007f-4c00-bec7-35d0e7ac322a"), "Направляющие на переговоры" },
                    { new Guid("35260ea7-f8c0-4dc9-b5db-5eb1c3f6f9fd"), "Нанимающиеся на работу" },
                    { new Guid("7e96ada8-98ec-42bc-92bf-c7fa450008d3"), "Направляющие на переговоры" }
                });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "BlitzGameRank", "CanBeAJury", "ClassicGameRank", "DateOfBirth", "Name", "Patronym", "Surname" },
                values: new object[] { new Guid("18bd477b-ca58-4043-a604-97f982af5adb"), 1, true, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иван", "Иванович", "Иванов" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("34af7e1d-650e-442c-b3be-7009cc663452"), "Судья" },
                    { new Guid("3ad11b96-7179-4b1b-b952-d424baa65063"), "Зритель" },
                    { new Guid("8a26c2d5-732d-4f86-949a-ccd1dadc008c"), "Арбитр" },
                    { new Guid("995eddbf-f325-4d2d-aac1-0c50a6f2fdda"), "Игрок" },
                    { new Guid("aca33ae0-fa95-4646-a1e6-109e083bb004"), "Секретарь" },
                    { new Guid("b932ba3e-db64-46c3-a9c6-b670e3c6bfb4"), "Не выбрана" },
                    { new Guid("db4aa28c-8972-4fe7-8e8e-23a834da51ed"), "Секундант" },
                    { new Guid("ea0d205d-cb52-4ce3-a5e5-4268aabc96e1"), "Тренер" }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "SchoolName" },
                values: new object[] { new Guid("999d00d8-37eb-4c40-9801-b093e8637418"), "Нет школы" });

            migrationBuilder.InsertData(
                table: "TournamentFormats",
                columns: new[] { "Id", "Format" },
                values: new object[,]
                {
                    { new Guid("638d80b6-e2dc-44c5-8e30-9aea41961371"), "Оффлайн" },
                    { new Guid("9fb332c4-3da5-4e21-b65a-40141bf16862"), "Онлайн" },
                    { new Guid("f2d995eb-e723-4dc7-98fe-4546c89102eb"), "Гибридный" }
                });

            migrationBuilder.InsertData(
                table: "TournamentGridTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("0a2cdc81-9bb5-42ae-9845-4739926a04d0"), "По командам" },
                    { new Guid("19101977-e0b6-403b-bbfe-1f9936bd4173"), "Каждый с каждым" },
                    { new Guid("2014f0b8-238a-41f4-9675-1b473f4e79eb"), "Комбинированный" },
                    { new Guid("a6438e73-e452-46ab-896d-0648b026444e"), "Навылет" }
                });

            migrationBuilder.InsertData(
                table: "TournamentTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("07a66472-4864-49d4-807b-45caaf1700c9"), "Практикум" },
                    { new Guid("1e52cfd3-7aa0-4155-8f19-99735b1fa964"), "Именной" },
                    { new Guid("93c12f4a-2739-42a4-a792-0c717779f5ec"), "Товарищеский" },
                    { new Guid("b982ea85-bb43-41d7-ade2-8e2fc8493f17"), "Отборочный" },
                    { new Guid("f31c0d8b-4d69-433b-9d8f-e30e5989a73c"), "Финал года" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Address", "City", "Date", "EndTime", "Number", "StartTime", "TournamentFormatId", "TournamentGridId", "TournamentName", "TournamentTypeId" },
                values: new object[] { new Guid("89e4433c-587b-4ddd-a79f-e58c3edee594"), "Пушкина0", "Томск", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), 0, new TimeSpan(0, 0, 0, 0, 0), new Guid("638d80b6-e2dc-44c5-8e30-9aea41961371"), new Guid("0a2cdc81-9bb5-42ae-9845-4739926a04d0"), "Турнир в Томске0", new Guid("07a66472-4864-49d4-807b-45caaf1700c9") });

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
                name: "TournamentFormats");

            migrationBuilder.DropTable(
                name: "TournamentGridTypes");

            migrationBuilder.DropTable(
                name: "TournamentTypes");
        }
    }
}
