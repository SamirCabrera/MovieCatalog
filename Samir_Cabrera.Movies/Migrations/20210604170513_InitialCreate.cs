﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Samir_Cabrera.Movies.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Like = table.Column<bool>(nullable: false),
                    View = table.Column<bool>(nullable: false),
                    ToViewLater = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Like", "Title", "ToViewLater", "View" },
                values: new object[] { 1, "http://sample.com", true, "s", false, false });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Like", "Title", "ToViewLater", "View" },
                values: new object[] { 2, "http://sample.com", true, "s", false, false });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "MovieId", "Url" },
                values: new object[] { 1, 1, "s" });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "MovieId", "Url" },
                values: new object[] { 2, 2, "s" });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "MovieId", "Url" },
                values: new object[] { 3, 2, "s" });

            migrationBuilder.CreateIndex(
                name: "IX_Image_MovieId",
                table: "Image",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
