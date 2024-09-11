using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eticaretsitesi.Migrations
{
    /// <inheritdoc />
    public partial class paket10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryId",
                table: "Products",
                type: "int",
                nullable: true);
        }
    }
}
