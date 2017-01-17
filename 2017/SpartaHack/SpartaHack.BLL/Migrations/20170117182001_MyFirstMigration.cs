using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartaHack.BLL.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduleItems",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    time = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    updatedAt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleItems", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    level = table.Column<string>(nullable: true),
                    logo_png_dark = table.Column<string>(nullable: true),
                    logo_png_light = table.Column<string>(nullable: true),
                    logo_svg_dark = table.Column<string>(nullable: true),
                    logo_svg_light = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CurrentUser",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    auth_token = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    password_confirmation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentUser", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Prizes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    sponsorid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prizes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Prizes_Sponsors_sponsorid",
                        column: x => x.sponsorid,
                        principalTable: "Sponsors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prizes_sponsorid",
                table: "Prizes",
                column: "sponsorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prizes");

            migrationBuilder.DropTable(
                name: "ScheduleItems");

            migrationBuilder.DropTable(
                name: "CurrentUser");

            migrationBuilder.DropTable(
                name: "Sponsors");
        }
    }
}
