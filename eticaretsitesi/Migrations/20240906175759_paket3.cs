using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eticaretsitesi.Migrations
{
    /// <inheritdoc />
    public partial class paket3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    AdvertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AdvertPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvertLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.AdvertId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adverts");
        }
    }
}
