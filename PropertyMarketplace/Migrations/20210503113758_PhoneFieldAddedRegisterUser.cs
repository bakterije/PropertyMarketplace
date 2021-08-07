using Microsoft.EntityFrameworkCore.Migrations;

namespace PropertyMarketplace.Migrations
{
    public partial class PhoneFieldAddedRegisterUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Category_categoryId",
                table: "AdsBasicInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoMoto_Category_categoryId",
                table: "AutoMoto");

            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturers_Category_categoryId",
                table: "Manufacturers");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_Category_categoryId",
                table: "Property");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Property",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Property_categoryId",
                table: "Property",
                newName: "IX_Property_CategoryId");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Manufacturers",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Manufacturers_categoryId",
                table: "Manufacturers",
                newName: "IX_Manufacturers_CategoryId");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Category",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "AutoMoto",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_AutoMoto_categoryId",
                table: "AutoMoto",
                newName: "IX_AutoMoto_CategoryId");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "AdsBasicInfo",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_categoryId",
                table: "AdsBasicInfo",
                newName: "IX_Ads_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "FloorArea",
                table: "Property",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Category_CategoryId",
                table: "AdsBasicInfo",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoMoto_Category_CategoryId",
                table: "AutoMoto",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturers_Category_CategoryId",
                table: "Manufacturers",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Category_CategoryId",
                table: "Property",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Category_CategoryId",
                table: "AdsBasicInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoMoto_Category_CategoryId",
                table: "AutoMoto");

            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturers_Category_CategoryId",
                table: "Manufacturers");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_Category_CategoryId",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "FloorArea",
                table: "Property");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Property",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Property_CategoryId",
                table: "Property",
                newName: "IX_Property_categoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Manufacturers",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Manufacturers_CategoryId",
                table: "Manufacturers",
                newName: "IX_Manufacturers_categoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Category",
                newName: "categoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "AutoMoto",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_AutoMoto_CategoryId",
                table: "AutoMoto",
                newName: "IX_AutoMoto_categoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "AdsBasicInfo",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_CategoryId",
                table: "AdsBasicInfo",
                newName: "IX_Ads_categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Category_categoryId",
                table: "AdsBasicInfo",
                column: "categoryId",
                principalTable: "Category",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoMoto_Category_categoryId",
                table: "AutoMoto",
                column: "categoryId",
                principalTable: "Category",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturers_Category_categoryId",
                table: "Manufacturers",
                column: "categoryId",
                principalTable: "Category",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Category_categoryId",
                table: "Property",
                column: "categoryId",
                principalTable: "Category",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
