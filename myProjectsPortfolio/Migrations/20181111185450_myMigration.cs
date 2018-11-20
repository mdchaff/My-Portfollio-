using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace myProjectsPortfolio.Migrations
{
    public partial class myMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AngAutos",
                columns: table => new
                {
                    AngAuto_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    projectName = table.Column<string>(nullable: true),
                    thePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AngAutos", x => x.AngAuto_ID);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Job_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    applied = table.Column<bool>(nullable: false),
                    company = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    epoch = table.Column<string>(nullable: true),
                    legal = table.Column<string>(nullable: true),
                    logo = table.Column<string>(nullable: true),
                    position = table.Column<string>(nullable: true),
                    slug = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Job_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PasswordC = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "Installs",
                columns: table => new
                {
                    Install_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AngAuto_ID = table.Column<int>(nullable: false),
                    TheInstall = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installs", x => x.Install_ID);
                    table.ForeignKey(
                        name: "FK_Installs_AngAutos_AngAuto_ID",
                        column: x => x.AngAuto_ID,
                        principalTable: "AngAutos",
                        principalColumn: "AngAuto_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Joineds",
                columns: table => new
                {
                    Joined_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Job_ID = table.Column<int>(nullable: false),
                    User_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joineds", x => x.Joined_ID);
                    table.ForeignKey(
                        name: "FK_Joineds_Jobs_Job_ID",
                        column: x => x.Job_ID,
                        principalTable: "Jobs",
                        principalColumn: "Job_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Joineds_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Installs_AngAuto_ID",
                table: "Installs",
                column: "AngAuto_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Joineds_Job_ID",
                table: "Joineds",
                column: "Job_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Joineds_User_ID",
                table: "Joineds",
                column: "User_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Installs");

            migrationBuilder.DropTable(
                name: "Joineds");

            migrationBuilder.DropTable(
                name: "AngAutos");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
