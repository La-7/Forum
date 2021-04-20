using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Domain.Migrations
{
    public partial class Somefixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Forums_ForumId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Forums");

            migrationBuilder.RenameColumn(
                name: "ForumId",
                table: "Posts",
                newName: "ThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_ForumId",
                table: "Posts",
                newName: "IX_Posts_ThemeId");

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Themes_ThemeId",
                table: "Posts",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Themes_ThemeId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.RenameColumn(
                name: "ThemeId",
                table: "Posts",
                newName: "ForumId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_ThemeId",
                table: "Posts",
                newName: "IX_Posts_ForumId");

            migrationBuilder.CreateTable(
                name: "Forums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forums", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Forums_ForumId",
                table: "Posts",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
