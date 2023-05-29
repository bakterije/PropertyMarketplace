using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PropertyMarketplace.Migrations
{
    public partial class NewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "AdsBasicInfo",
               columns: table => new
               {
                   AdID = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   OwnerID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                   Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   ListingCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                   CategoryId = table.Column<int>(type: "int", nullable: false),
                   Condition = table.Column<int>(type: "int", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Ads", x => x.AdID);
                   table.ForeignKey(
                       name: "FK_Ads_Category_CategoryId",
                       column: x => x.CategoryId,
                       principalTable: "Category",
                       principalColumn: "categoryId",
                       onDelete: ReferentialAction.NoAction);
               });
            migrationBuilder.CreateTable(
                           name: "Property",
                           columns: table => new
                           {
                               PropertyID = table.Column<int>(type: "int", nullable: false)
                                   .Annotation("SqlServer:Identity", "1, 1"),
                               HouseType = table.Column<int>(type: "int", nullable: false),
                               EnergyRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                               NumberOfRooms = table.Column<int>(type: "int", nullable: false),
                               AdID = table.Column<int>(type: "int", nullable: false),
                               OwnerID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                               CategoryId = table.Column<int>(type: "int", nullable: false)
                           },
                           constraints: table =>
                           {
                               table.PrimaryKey("PK_Property", x => x.PropertyID);
                               table.ForeignKey(
                                   name: "FK_Property_Ads_AdID",
                                   column: x => x.AdID,
                                   principalTable: "AdsBasicInfo",
                                   principalColumn: "AdID",
                                   onDelete: ReferentialAction.Cascade);
                               table.ForeignKey(
                                   name: "FK_Property_Category_CategoryId",
                                   column: x => x.CategoryId,
                                   principalTable: "Category",
                                   principalColumn: "categoryId",
                                   onDelete: ReferentialAction.NoAction);
                           });
            migrationBuilder.CreateTable(
               name: "AutoMoto",
               columns: table => new
               {
                   AutoMotoID = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   YearOfManufacture = table.Column<int>(type: "int", nullable: false),
                   Mileage = table.Column<int>(type: "int", nullable: false),
                   ManufacturerID = table.Column<int>(type: "int", nullable: false),
                   ModelID = table.Column<int>(type: "int", nullable: false),
                   TransmissionType = table.Column<int>(type: "int", nullable: false),
                   AdID = table.Column<int>(type: "int", nullable: false),
                   OwnerID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   CategoryId = table.Column<int>(type: "int", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_AutoMoto", x => x.AutoMotoID);
                   table.ForeignKey(
                       name: "FK_AutoMoto_Ads_AdID",
                       column: x => x.AdID,
                       principalTable: "AdsBasicInfo",
                       principalColumn: "AdID",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_AutoMoto_CarModels_ModelID",
                       column: x => x.ModelID,
                       principalTable: "AutoMotoModels",
                       principalColumn: "ModelID",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_AutoMoto_Category_CategoryId",
                       column: x => x.CategoryId,
                       principalTable: "Category",
                       principalColumn: "categoryId",
                       onDelete: ReferentialAction.NoAction);
                   table.ForeignKey(
                       name: "FK_AutoMoto_Manufacturers_ManufacturerID",
                       column: x => x.ManufacturerID,
                       principalTable: "Manufacturers",
                       principalColumn: "ManufacturerID",
                       onDelete: ReferentialAction.NoAction);
               });
            migrationBuilder.CreateIndex(
               name: "IX_Ads_CategoryId",
               table: "AdsBasicInfo",
               column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMoto_AdID",
                table: "AutoMoto",
                column: "AdID");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMoto_CategoryId",
                table: "AutoMoto",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMoto_ManufacturerID",
                table: "AutoMoto",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMoto_ModelID",
                table: "AutoMoto",
                column: "ModelID");
            migrationBuilder.CreateIndex(
                name: "IX_Property_AdID",
                table: "Property",
                column: "AdID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_CategoryId",
                table: "Property",
                column: "categoryId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "AutoMoto");

            migrationBuilder.DropTable(
                name: "Property");
            migrationBuilder.DropTable(
              name: "AdsBasicInfo");
        }
    }
}
