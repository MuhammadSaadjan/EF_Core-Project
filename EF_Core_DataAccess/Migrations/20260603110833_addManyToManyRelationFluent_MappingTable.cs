using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addManyToManyRelationFluent_MappingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fluent_AuthorFluent_Book");

            migrationBuilder.CreateTable(
                name: "Fluent_BookAuthorMap",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_BookAuthorMap", x => new { x.Author_Id, x.Book_Id });
                    table.ForeignKey(
                        name: "FK_Fluent_BookAuthorMap_Fluent_Author_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "Fluent_Author",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fluent_BookAuthorMap_Fluent_Book_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Fluent_Book",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookAuthorMap_Book_Id",
                table: "Fluent_BookAuthorMap",
                column: "Book_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fluent_BookAuthorMap");

            migrationBuilder.CreateTable(
                name: "Fluent_AuthorFluent_Book",
                columns: table => new
                {
                    AuthorsAuthor_Id = table.Column<int>(type: "int", nullable: false),
                    BooksBook_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_AuthorFluent_Book", x => new { x.AuthorsAuthor_Id, x.BooksBook_Id });
                    table.ForeignKey(
                        name: "FK_Fluent_AuthorFluent_Book_Fluent_Author_AuthorsAuthor_Id",
                        column: x => x.AuthorsAuthor_Id,
                        principalTable: "Fluent_Author",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fluent_AuthorFluent_Book_Fluent_Book_BooksBook_Id",
                        column: x => x.BooksBook_Id,
                        principalTable: "Fluent_Book",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_AuthorFluent_Book_BooksBook_Id",
                table: "Fluent_AuthorFluent_Book",
                column: "BooksBook_Id");
        }
    }
}
