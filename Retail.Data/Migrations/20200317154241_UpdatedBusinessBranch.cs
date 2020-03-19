using Microsoft.EntityFrameworkCore.Migrations;

namespace Retail.Data.Migrations
{
    public partial class UpdatedBusinessBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "BusinessBranches",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "BusinessBranches",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAddress",
                table: "BusinessBranches",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalAddress",
                table: "BusinessBranches",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "BusinessBranches");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "BusinessBranches");

            migrationBuilder.DropColumn(
                name: "PhysicalAddress",
                table: "BusinessBranches");

            migrationBuilder.DropColumn(
                name: "PostalAddress",
                table: "BusinessBranches");
        }
    }
}
