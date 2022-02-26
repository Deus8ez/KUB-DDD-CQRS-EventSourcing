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
                    Number = table.Column<int>(type: "int", nullable: false)
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
                    { new Guid("88f81266-0059-4bb2-837b-4c49f8bc9f2f"), "Направляющие на переговоры" },
                    { new Guid("9ca4c875-3c7c-417a-b4fb-80f84daab701"), "Нанимающиеся на работу" },
                    { new Guid("ed201a24-dd57-47cb-b6d1-e1a132d5862b"), "Направляющие на переговоры" }
                });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "BlitzGameRank", "CanBeAJury", "ClassicGameRank", "DateOfBirth", "Name", "Patronym", "Surname" },
                values: new object[] { new Guid("a3b55f01-76ea-4c75-a9a6-cb815782048c"), 1, true, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иван", "Иванович", "Иванов" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("2934aac0-bdd4-4e24-b748-29586ab52e34"), "Судья" },
                    { new Guid("32a3f9f9-9e66-41ca-9a97-a93b19a167b1"), "Не выбрана" },
                    { new Guid("3b1b9c1f-772f-44c9-8838-a998ee546b11"), "Зритель" },
                    { new Guid("553b4bf6-380d-449e-8518-0a9b1b9e24cb"), "Арбитр" },
                    { new Guid("6cb3cd92-90f6-4a05-b245-e6e2c6d645e6"), "Игрок" },
                    { new Guid("6d1763a6-17e2-452a-81dc-d6ba029082b1"), "Секретарь" },
                    { new Guid("bda8d486-82fe-447c-8e79-0c4949da0e2d"), "Тренер" },
                    { new Guid("e0c98ccb-3827-40fe-98df-609f16f55cc1"), "Секундант" }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "SchoolName" },
                values: new object[] { new Guid("cc0eb01f-1664-4a60-9b5a-1103537b3d49"), "Нет школы" });

            migrationBuilder.InsertData(
                table: "TournamentFormats",
                columns: new[] { "Id", "Format" },
                values: new object[,]
                {
                    { new Guid("0875d603-3b26-4fa9-850f-a5d9c7c03c1b"), "Оффлайн" },
                    { new Guid("6677162d-d01c-48fe-8b0a-724315973bde"), "Онлайн" },
                    { new Guid("6fcecfb6-a91a-4e37-8494-8d5ca117a50e"), "Гибридный" }
                });

            migrationBuilder.InsertData(
                table: "TournamentGridTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("2019b611-9075-4326-bb50-b32d13287a7a"), "Каждый с каждым" },
                    { new Guid("2b19f75f-685d-47b8-b12e-d5dacce02bcb"), "Навылет" },
                    { new Guid("61453fc3-f129-4dd3-9282-e61a56a66e8d"), "По командам" },
                    { new Guid("ba19e2be-a89c-4415-9f90-82a61a5f80bd"), "Комбинированный" }
                });

            migrationBuilder.InsertData(
                table: "TournamentTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("2c48823c-90cc-4bde-abea-890e33ba21fa"), "Именной" },
                    { new Guid("384df408-f194-4922-8ff4-2abb0a5be368"), "Практикум" },
                    { new Guid("67009bb0-3b0e-4c21-a595-47a6caac4566"), "Товарищеский" },
                    { new Guid("7a1bf0d5-5d9a-44a7-907c-df1ee8198c75"), "Финал года" },
                    { new Guid("9329b1c1-fbcb-460e-8f11-0a45e0fbeba2"), "Отборочный" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Address", "City", "Date", "EndTime", "Number", "StartTime", "TournamentFormatId", "TournamentGridId", "TournamentName", "TournamentTypeId" },
                values: new object[] { new Guid("4d3ebcf0-b4b7-45f5-98db-a4121e891372"), "Пушкина0", "Томск", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), 0, new TimeSpan(0, 0, 0, 0, 0), new Guid("0875d603-3b26-4fa9-850f-a5d9c7c03c1b"), new Guid("61453fc3-f129-4dd3-9282-e61a56a66e8d"), "Турнир в Томске0", new Guid("384df408-f194-4922-8ff4-2abb0a5be368") });

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
