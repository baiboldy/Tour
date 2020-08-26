using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KolesaTwo.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 500, nullable: false),
                    dateFrom = table.Column<DateTime>(nullable: false),
                    dateTo = table.Column<DateTime>(nullable: false),
                    peopleLimit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Guide",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 500, nullable: false),
                    experienceCount = table.Column<int>(nullable: false),
                    tourId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guide", x => x.id);
                    table.ForeignKey(
                        name: "FK_Guide_Tour_tourId",
                        column: x => x.tourId,
                        principalTable: "Tour",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 500, nullable: false),
                    tourId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.id);
                    table.ForeignKey(
                        name: "FK_Place_Tour_tourId",
                        column: x => x.tourId,
                        principalTable: "Tour",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guide_tourId",
                table: "Guide",
                column: "tourId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_tourId",
                table: "Place",
                column: "tourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guide");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "Tour");
        }
    }
}
