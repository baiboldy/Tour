using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KolesaTwo.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tour_Guide_GuideId",
                table: "Tour");

            migrationBuilder.DropForeignKey(
                name: "FK_Tour_Place_PlaceId",
                table: "Tour");

            migrationBuilder.DropForeignKey(
                name: "FK_TourLink_Tour_TourId",
                table: "TourLink");

            migrationBuilder.DropIndex(
                name: "IX_Tour_GuideId",
                table: "Tour");

            migrationBuilder.DropIndex(
                name: "IX_Tour_PlaceId",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "GuideId",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Tour");

            migrationBuilder.AlterColumn<Guid>(
                name: "TourId",
                table: "TourLink",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TourLink_Tour_TourId",
                table: "TourLink",
                column: "TourId",
                principalTable: "Tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourLink_Tour_TourId",
                table: "TourLink");

            migrationBuilder.AlterColumn<Guid>(
                name: "TourId",
                table: "TourLink",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "GuideId",
                table: "Tour",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlaceId",
                table: "Tour",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tour_GuideId",
                table: "Tour",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_PlaceId",
                table: "Tour",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tour_Guide_GuideId",
                table: "Tour",
                column: "GuideId",
                principalTable: "Guide",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tour_Place_PlaceId",
                table: "Tour",
                column: "PlaceId",
                principalTable: "Place",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TourLink_Tour_TourId",
                table: "TourLink",
                column: "TourId",
                principalTable: "Tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
