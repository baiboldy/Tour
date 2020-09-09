using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KolesaTwo.Migrations
{
    public partial class added_link_table_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TourLink",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GuideId = table.Column<Guid>(nullable: true),
                    PlaceId = table.Column<Guid>(nullable: true),
                    TourId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourLink_Guide_GuideId",
                        column: x => x.GuideId,
                        principalTable: "Guide",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TourLink_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TourLink_Tour_TourId",
                        column: x => x.TourId,
                        principalTable: "Tour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourLink_GuideId",
                table: "TourLink",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_TourLink_PlaceId",
                table: "TourLink",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_TourLink_TourId",
                table: "TourLink",
                column: "TourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourLink");
        }
    }
}
