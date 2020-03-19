using Microsoft.EntityFrameworkCore.Migrations;

namespace Retail.Data.Migrations
{
    public partial class AddedBusinessType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusinessType",
                table: "Businesses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessType",
                table: "Businesses");
        }
    }
}
