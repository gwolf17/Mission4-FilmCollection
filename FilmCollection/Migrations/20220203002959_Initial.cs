using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmCollection.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    categoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    categoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    movieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    director = table.Column<string>(nullable: false),
                    rating = table.Column<string>(nullable: false),
                    edited = table.Column<bool>(nullable: false),
                    lentTo = table.Column<string>(nullable: true),
                    notes = table.Column<string>(maxLength: 25, nullable: true),
                    categoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.movieId);
                    table.ForeignKey(
                        name: "FK_responses_category_categoryId",
                        column: x => x.categoryId,
                        principalTable: "category",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "categoryId", "categoryName" },
                values: new object[] { 1, "Action/Adventure" });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "categoryId", "categoryName" },
                values: new object[] { 2, "Comedy" });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "categoryId", "categoryName" },
                values: new object[] { 3, "Drama" });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "categoryId", "categoryName" },
                values: new object[] { 4, "Family" });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "categoryId", "categoryName" },
                values: new object[] { 5, "Horror/Suspense" });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "categoryId", "categoryName" },
                values: new object[] { 6, "Miscellaneous" });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "categoryId", "categoryName" },
                values: new object[] { 7, "Romance" });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "categoryId", "categoryName" },
                values: new object[] { 8, "Television" });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "categoryId", "categoryName" },
                values: new object[] { 9, "VHS" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "movieId", "categoryId", "director", "edited", "lentTo", "notes", "rating", "title", "year" },
                values: new object[] { 1, 1, "Anthony & Joe Russo", false, "", "Best Captain America movie.", "PG-13", "Captain America Winter Soldier", 2014 });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "movieId", "categoryId", "director", "edited", "lentTo", "notes", "rating", "title", "year" },
                values: new object[] { 2, 7, "Rob Reiner", false, "Shannon", "One of the greatest movies ever. End of story.", "PG", "The Princess Bride", 1987 });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "movieId", "categoryId", "director", "edited", "lentTo", "notes", "rating", "title", "year" },
                values: new object[] { 3, 7, "John Turteltaub", false, "", "", "PG", "While you were Sleeping", 1995 });

            migrationBuilder.CreateIndex(
                name: "IX_responses_categoryId",
                table: "responses",
                column: "categoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
