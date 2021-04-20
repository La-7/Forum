using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Domain.Migrations
{
    public partial class AddedIsBannedTillfieldinUserclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "IsBannedTill",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBannedTill",
                table: "AspNetUsers");
        }
    }
}
