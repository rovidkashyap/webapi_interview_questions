using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paging_sorting_filtering_in_web_api.Migrations
{
    public partial class Initial_Setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Category 1", "Product 1", 10.00m },
                    { 2, "Category 2", "Product 2", 20.00m },
                    { 3, "Category 1", "Product 3", 30.00m },
                    { 4, "Category 3", "Product 4", 40.00m },
                    { 5, "Category 2", "Product 5", 50.00m },
                    { 6, "Category 3", "Product 6", 60.00m },
                    { 7, "Category 1", "Product 7", 70.00m },
                    { 8, "Category 2", "Product 8", 80.00m },
                    { 9, "Category 3", "Product 9", 90.00m },
                    { 10, "Category 1", "Product 10", 100.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
