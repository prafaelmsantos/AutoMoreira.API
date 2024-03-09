using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoMoreira.Persistence.Migrations
{
    public partial class _000002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_read_only",
                table: "roles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "is_default", "is_read_only" },
                values: new object[] { "5aa4f9ab-7f36-4ff8-8e49-bc67a8a97c7a", false, true });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "concurrency_stamp", "is_default", "is_read_only" },
                values: new object[] { "c0239276-4352-49ee-bf1a-e7d645547967", true, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_read_only",
                table: "roles");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "is_default" },
                values: new object[] { "e5a70ff8-d492-448c-b6f4-1aeffe9e985c", true });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "concurrency_stamp", "is_default" },
                values: new object[] { "4f941683-a3f7-446f-9dad-15f79c80af5f", false });
        }
    }
}
