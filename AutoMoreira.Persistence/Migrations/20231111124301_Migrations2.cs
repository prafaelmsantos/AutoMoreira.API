using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoMoreira.Persistence.Migrations
{
    public partial class Migrations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "contact",
                newName: "phone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phone",
                table: "contact",
                newName: "phone_number");
        }
    }
}
