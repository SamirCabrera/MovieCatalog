using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                    Id = table.Column<Guid>(nullable: false),
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
                    Id = table.Column<Guid>(nullable: false),
                    MovieId = table.Column<Guid>(nullable: false),
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
                values: new object[] { new Guid("aa3f8665-a004-4e5d-9296-5633579c9648"), "http://sample.com", true, "s", false, false });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Like", "Title", "ToViewLater", "View" },
                values: new object[] { new Guid("2b983e46-e960-40af-9b03-3c62d9e140ab"), "http://sample.com", true, "s", false, false });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "MovieId", "Url" },
                values: new object[] { new Guid("7790df72-27a3-4a08-91ff-f428a1d6e919"), new Guid("aa3f8665-a004-4e5d-9296-5633579c9648"), "s" });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "MovieId", "Url" },
                values: new object[] { new Guid("d7ac925f-999b-49f8-b201-7405957685f7"), new Guid("2b983e46-e960-40af-9b03-3c62d9e140ab"), "s" });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "MovieId", "Url" },
                values: new object[] { new Guid("6bfae1bc-18ff-434b-b10c-0a2defb867bd"), new Guid("2b983e46-e960-40af-9b03-3c62d9e140ab"), "s" });

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
