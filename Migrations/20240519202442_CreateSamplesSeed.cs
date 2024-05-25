using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    public partial class CreateSamplesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Genre", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", "Classic", 10.99m, "The Great Gatsby" },
                    { 2, "Harper Lee", "Classic", 7.99m, "To Kill a Mockingbird" },
                    { 3, "George Orwell", "Dystopian", 8.99m, "1984" },
                    { 4, "Jane Austen", "Romance", 6.99m, "Pride and Prejudice" },
                    { 5, "J.D. Salinger", "Classic", 9.99m, "The Catcher in the Rye" },
                    { 6, "J.R.R. Tolkien", "Fantasy", 12.99m, "The Hobbit" },
                    { 7, "J.K. Rowling", "Fantasy", 11.99m, "Harry Potter and the Philosopher's Stone" },
                    { 8, "J.R.R. Tolkien", "Fantasy", 15.99m, "The Lord of the Rings" },
                    { 9, "Paulo Coelho", "Adventure", 9.99m, "The Alchemist" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
