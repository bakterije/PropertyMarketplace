using Microsoft.EntityFrameworkCore.Migrations;

namespace PropertyMarketplace.Migrations
{
    public partial class SubCategoryIdAddedInManufacturers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Manufacturers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Manufacturers");
        }
    }
}
