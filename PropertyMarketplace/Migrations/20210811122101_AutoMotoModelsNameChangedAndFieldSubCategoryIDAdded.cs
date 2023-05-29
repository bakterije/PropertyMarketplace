using Microsoft.EntityFrameworkCore.Migrations;

namespace PropertyMarketplace.Migrations
{
    public partial class AutoMotoModelsNameChangedAndFieldSubCategoryIDAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubCategoryID",
                table: "AutoMotoModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCategoryID",
                table: "AutoMotoModels");
        }
    }
}
