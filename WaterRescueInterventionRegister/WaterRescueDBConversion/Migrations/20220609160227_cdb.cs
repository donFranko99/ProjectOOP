using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaterRescueDBConversion.Migrations
{
    public partial class cdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InterventionTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InterventionReport = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lifeguards",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleID = table.Column<int>(type: "INTEGER", nullable: false),
                    LifeguardName = table.Column<string>(type: "TEXT", nullable: true),
                    LifeguardSurname = table.Column<string>(type: "TEXT", nullable: true),
                    LifeguardPhoneNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lifeguards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lifeguards_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interventions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReportID = table.Column<int>(type: "INTEGER", nullable: false),
                    LifeguardID = table.Column<int>(type: "INTEGER", nullable: false),
                    ResponseTime = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interventions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Interventions_Lifeguards_LifeguardID",
                        column: x => x.LifeguardID,
                        principalTable: "Lifeguards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interventions_Reports_ReportID",
                        column: x => x.ReportID,
                        principalTable: "Reports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interventions_LifeguardID",
                table: "Interventions",
                column: "LifeguardID");

            migrationBuilder.CreateIndex(
                name: "IX_Interventions_ReportID",
                table: "Interventions",
                column: "ReportID");

            migrationBuilder.CreateIndex(
                name: "IX_Lifeguards_RoleID",
                table: "Lifeguards",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interventions");

            migrationBuilder.DropTable(
                name: "Lifeguards");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
