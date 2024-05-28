using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KAST.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    URL = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Delete = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    FactionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Flag = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    UseSide = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Delete = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.FactionId);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    MissionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    MissionDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    StartTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ShortDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Worldanme = table.Column<string>(type: "TEXT", nullable: true),
                    Template = table.Column<int>(type: "INTEGER", nullable: false),
                    RuleLink = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    MissionBriefingLink = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Delete = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.MissionId);
                });

            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    InstallPath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    EMail = table.Column<string>(type: "TEXT", nullable: true),
                    SteamName = table.Column<string>(type: "TEXT", nullable: true),
                    SteamID = table.Column<ulong>(type: "INTEGER", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: true),
                    MissionCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Delete = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Mods",
                columns: table => new
                {
                    ModId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Path = table.Column<string>(type: "TEXT", nullable: true),
                    IsLocal = table.Column<bool>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: true),
                    ActualSize = table.Column<ulong>(type: "INTEGER", nullable: false),
                    AuthorId = table.Column<Guid>(type: "TEXT", nullable: true),
                    SteamID = table.Column<ulong>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    SteamLastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LocalLastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ExpectedSize = table.Column<ulong>(type: "INTEGER", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Delete = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mods", x => x.ModId);
                    table.ForeignKey(
                        name: "FK_Mods_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId");
                });

            migrationBuilder.CreateTable(
                name: "Squads",
                columns: table => new
                {
                    SquadId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MissionID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxUsuerCount = table.Column<int>(type: "INTEGER", nullable: false),
                    SquadPolicy = table.Column<int>(type: "INTEGER", nullable: false),
                    GameSide = table.Column<int>(type: "INTEGER", nullable: false),
                    FactionID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Delete = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squads", x => x.SquadId);
                    table.ForeignKey(
                        name: "FK_Squads_Factions_FactionID",
                        column: x => x.FactionID,
                        principalTable: "Factions",
                        principalColumn: "FactionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Squads_Missions_MissionID",
                        column: x => x.MissionID,
                        principalTable: "Missions",
                        principalColumn: "MissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fireteams",
                columns: table => new
                {
                    FireteamId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RestrictTeamCompoition = table.Column<bool>(type: "INTEGER", nullable: false),
                    InviteOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    SquadId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SlotsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Delete = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fireteams", x => x.FireteamId);
                    table.ForeignKey(
                        name: "FK_Fireteams_Squads_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squads",
                        principalColumn: "SquadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissionUsers",
                columns: table => new
                {
                    MissionUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SquadID = table.Column<Guid>(type: "TEXT", nullable: false),
                    MissionID = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Delete = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionUsers", x => x.MissionUserId);
                    table.ForeignKey(
                        name: "FK_MissionUsers_Missions_MissionID",
                        column: x => x.MissionID,
                        principalTable: "Missions",
                        principalColumn: "MissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionUsers_Squads_SquadID",
                        column: x => x.SquadID,
                        principalTable: "Squads",
                        principalColumn: "SquadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionUsers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    SlotId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SlotNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Label = table.Column<string>(type: "TEXT", nullable: true),
                    FireteamID = table.Column<Guid>(type: "TEXT", nullable: false),
                    MissionUserID = table.Column<Guid>(type: "TEXT", nullable: true),
                    Timestamp = table.Column<long>(type: "INTEGER", nullable: true),
                    Role = table.Column<int>(type: "INTEGER", nullable: true),
                    IsValideted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Delete = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => x.SlotId);
                    table.ForeignKey(
                        name: "FK_Slots_Fireteams_FireteamID",
                        column: x => x.FireteamID,
                        principalTable: "Fireteams",
                        principalColumn: "FireteamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slots_MissionUsers_MissionUserID",
                        column: x => x.MissionUserID,
                        principalTable: "MissionUsers",
                        principalColumn: "MissionUserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fireteams_SquadId",
                table: "Fireteams",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionUsers_MissionID",
                table: "MissionUsers",
                column: "MissionID");

            migrationBuilder.CreateIndex(
                name: "IX_MissionUsers_SquadID",
                table: "MissionUsers",
                column: "SquadID");

            migrationBuilder.CreateIndex(
                name: "IX_MissionUsers_UserID",
                table: "MissionUsers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Mods_AuthorId",
                table: "Mods",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Slots_FireteamID",
                table: "Slots",
                column: "FireteamID");

            migrationBuilder.CreateIndex(
                name: "IX_Slots_MissionUserID",
                table: "Slots",
                column: "MissionUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Squads_FactionID",
                table: "Squads",
                column: "FactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Squads_MissionID",
                table: "Squads",
                column: "MissionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mods");

            migrationBuilder.DropTable(
                name: "Servers");

            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Fireteams");

            migrationBuilder.DropTable(
                name: "MissionUsers");

            migrationBuilder.DropTable(
                name: "Squads");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropTable(
                name: "Missions");
        }
    }
}
