using Microsoft.EntityFrameworkCore.Migrations;

namespace PropertyMarketplace.Migrations
{
    public partial class ParentNameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "ParentName",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(
                name: "ParentName",
                table: "Category");
        }
    }
}

           