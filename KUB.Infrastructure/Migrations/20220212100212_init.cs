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
                    PanelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Panel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Коллегии судей", x => x.PanelId);
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
                    ParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    SchoolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "TournamentFormats",
                columns: table => new
                {
                    FormatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Формат проведения", x => x.FormatId);
                });

            migrationBuilder.CreateTable(
                name: "TournamentGridTypes",
                columns: table => new
                {
                    GridId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Вариант сетки турнира", x => x.GridId);
                });

            migrationBuilder.CreateTable(
                name: "TournamentTypes",
                columns: table => new
                {
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Типы турниров", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantInSchools",
                columns: table => new
                {
                    ParticipantInSchoolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantSchoolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantInSchools", x => x.ParticipantInSchoolId);
                    table.ForeignKey(
                        name: "FK_Участники в школах_Участники",
                        column: x => x.ParticipantInSchoolId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Участники в школах_Школы",
                        column: x => x.ParticipantSchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", fixedLength: true, nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", fixedLength: true, nullable: true),
                    TournamentFormatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentGridId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Турниры_Вариант сетки турнира",
                        column: x => x.TournamentGridId,
                        principalTable: "TournamentGridTypes",
                        principalColumn: "GridId");
                    table.ForeignKey(
                        name: "FK_Турниры_Место1",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Турниры_Типы турниров",
                        column: x => x.TournamentTypeId,
                        principalTable: "TournamentTypes",
                        principalColumn: "TypeId");
                    table.ForeignKey(
                        name: "FK_Турниры_Формат проведения",
                        column: x => x.TournamentFormatId,
                        principalTable: "TournamentFormats",
                        principalColumn: "FormatId");
                });

            migrationBuilder.CreateTable(
                name: "JuryInPanels",
                columns: table => new
                {
                    JuryInPanelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentWithJuryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JuryParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JuryPanelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuryInPanels", x => x.JuryInPanelId);
                    table.ForeignKey(
                        name: "FK_Судьи в коллегиях_Коллегии судей",
                        column: x => x.JuryPanelId,
                        principalTable: "JuryPanels",
                        principalColumn: "PanelId");
                    table.ForeignKey(
                        name: "FK_Судьи в коллегиях_Турниры",
                        column: x => x.TournamentWithJuryId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Судьи в коллегиях_Участники1",
                        column: x => x.JuryParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantInTournaments",
                columns: table => new
                {
                    TournamentWithParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantInId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Участники в турнирах", x => new { x.TournamentWithParticipantId, x.ParticipantInId });
                    table.ForeignKey(
                        name: "FK_Участники в турнирах_Роли",
                        column: x => x.ParticipantRoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Участники в турнирах_Турниры",
                        column: x => x.TournamentWithParticipantId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Участники в турнирах_Участники",
                        column: x => x.ParticipantInId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "JuryPanels",
                columns: new[] { "PanelId", "Panel" },
                values: new object[,]
                {
                    { new Guid("051265ea-4907-4824-8955-d0cae439dacf"), "Направляющие на переговоры" },
                    { new Guid("343c74d9-4cc3-4751-b903-6e37adcab7d8"), "Нанимающиеся на работу" },
                    { new Guid("c5f3ae6e-7249-4921-808e-bd299ca2c492"), "Направляющие на переговоры" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "City" },
                values: new object[] { new Guid("ec410634-fc15-4265-8082-3a7ecdce6a16"), "Пушкина 1", "Томск" });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "BlitzGameRank", "CanBeAJury", "ClassicGameRank", "DateOfBirth", "Name", "ParticipantId", "Patronym", "Surname" },
                values: new object[] { new Guid("84569a49-4578-45cd-97af-3348a295f6c8"), 1, true, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иван", new Guid("8d92c559-7044-4ab8-a5f3-b740e89cfdb5"), "Иванович", "Иванов" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("031f6a84-3d6f-4370-bb64-7bbabcfe835e"), "Зритель" },
                    { new Guid("0a7d298b-6448-4d47-bd28-78e8afa6c71a"), "Тренер" },
                    { new Guid("3795e34b-6f3b-4466-8ea8-5e0604df287c"), "Секретарь" },
                    { new Guid("73e25ef3-fe93-4b06-9773-2076cd4e30a9"), "Арбитр" },
                    { new Guid("95b72e2e-26e5-40f4-983b-078761abd750"), "Судья" },
                    { new Guid("bf009a0f-64f8-4737-9daf-d652f050b13f"), "Игрок" },
                    { new Guid("dba14a2d-c279-4bf8-bafe-f3411eadbecc"), "Секундант" },
                    { new Guid("eddd5acc-32b6-4e28-8fa8-617fe8e3da7b"), "Не выбрана" }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "SchoolId", "SchoolName" },
                values: new object[] { new Guid("221ef3c0-3615-4fc7-86bc-411289771405"), "Нет школы" });

            migrationBuilder.InsertData(
                table: "TournamentFormats",
                columns: new[] { "FormatId", "Format" },
                values: new object[,]
                {
                    { new Guid("310425a2-5f9f-46ae-91e2-4927b444a85b"), "Гибридный" },
                    { new Guid("b24d4ff9-f3c6-4a51-8457-8ea63fd138fb"), "Онлайн" },
                    { new Guid("da5a3e86-df85-4f70-a811-b11f2d26ade6"), "Оффлайн" }
                });

            migrationBuilder.InsertData(
                table: "TournamentGridTypes",
                columns: new[] { "GridId", "Type" },
                values: new object[,]
                {
                    { new Guid("9e6ad8d4-ff74-4c2f-9c7b-07fc2cef8639"), "Комбинированный" },
                    { new Guid("9f264d6a-c081-42f7-9d21-3898dc528827"), "По командам" },
                    { new Guid("c82599b5-1e1c-4067-88e1-f2d80d14afdd"), "Каждый с каждым" },
                    { new Guid("f00243d9-ba54-4df1-94ee-5ae6a593a88a"), "Навылет" }
                });

            migrationBuilder.InsertData(
                table: "TournamentTypes",
                columns: new[] { "TypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("1e79cb93-5137-442e-8a47-991d168c1ee3"), "Товарищеский" },
                    { new Guid("4637f7a0-a934-4135-8680-a34de1848272"), "Именной" },
                    { new Guid("8cc7a19a-0cb8-446f-a7c0-b5f6f771ba1c"), "Практикум" },
                    { new Guid("ae446207-6b4c-46eb-9503-92381bead9de"), "Финал года" },
                    { new Guid("f50f9026-7c63-4ba4-8639-a0fcca004592"), "Отборочный" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Date", "EndTime", "LocationId", "StartTime", "TournamentFormatId", "TournamentGridId", "TournamentName", "TournamentTypeId" },
                values: new object[] { new Guid("61bd568c-5fb6-4302-af89-da59b4dadb36"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), new Guid("ec410634-fc15-4265-8082-3a7ecdce6a16"), new TimeSpan(0, 0, 0, 0, 0), new Guid("da5a3e86-df85-4f70-a811-b11f2d26ade6"), new Guid("9f264d6a-c081-42f7-9d21-3898dc528827"), "Турнир в Томске", new Guid("8cc7a19a-0cb8-446f-a7c0-b5f6f771ba1c") });

            migrationBuilder.CreateIndex(
                name: "IX_JuryInPanels_JuryPanelId",
                table: "JuryInPanels",
                column: "JuryPanelId");

            migrationBuilder.CreateIndex(
                name: "IX_JuryInPanels_JuryParticipantId",
                table: "JuryInPanels",
                column: "JuryParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_JuryInPanels_TournamentWithJuryId",
                table: "JuryInPanels",
                column: "TournamentWithJuryId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantInSchools_ParticipantSchoolId",
                table: "ParticipantInSchools",
                column: "ParticipantSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantInTournaments_ParticipantInId",
                table: "ParticipantInTournaments",
                column: "ParticipantInId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantInTournaments_ParticipantRoleId",
                table: "ParticipantInTournaments",
                column: "ParticipantRoleId");

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
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "TournamentGridTypes");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "TournamentTypes");

            migrationBuilder.DropTable(
                name: "TournamentFormats");
        }
    }
}
