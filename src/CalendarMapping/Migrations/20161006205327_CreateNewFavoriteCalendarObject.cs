using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendarMapping.Migrations
{
    public partial class CreateNewFavoriteCalendarObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCalendars_Calendars_CalendarId",
                table: "FavoriteCalendars");

            migrationBuilder.AlterColumn<int>(
                name: "CalendarId",
                table: "FavoriteCalendars",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCalendars_Calendars_CalendarId",
                table: "FavoriteCalendars",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCalendars_Calendars_CalendarId",
                table: "FavoriteCalendars");

            migrationBuilder.AlterColumn<int>(
                name: "CalendarId",
                table: "FavoriteCalendars",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCalendars_Calendars_CalendarId",
                table: "FavoriteCalendars",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
