using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoMoreira.Persistence.Migrations
{
    public partial class Migration000001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_main",
                table: "vehicle_images",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "6e22a74e-2c26-45b7-8f57-f3c45b8f8263");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "d0761a56-cd23-4048-9013-64d3ce54b311");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "password_hash", "security_stamp" },
                values: new object[] { "963fff49-4769-43d8-a9e2-98b1fecce1dd", "AQAAAAEAACcQAAAAEIe3DGxckJk0XTI2zTyWnNFrhfTjmLtNXtMpiv3AgVXlCPdAFFkKJH5vUMnS2fP2Bg==", "311a203c-3178-44d7-a174-cfb8745316b9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_main",
                table: "vehicle_images");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "3f5814c9-ee24-4b35-a701-e9137bca961d");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "c3e59ecd-c99f-40a1-b7ca-7b79adc1c030");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "password_hash", "security_stamp" },
                values: new object[] { "c0aab5e2-4d6f-4093-a2ad-f85ad77c9169", "AQAAAAEAACcQAAAAEDMMFMlNH0fzo8Rci3d1YLHRv9WrmvHQMY0hJ4srfDVy9v1K42u9k2Zd0tkHEvo0pA==", "7a169789-ef15-4992-a704-426d2a56dda1" });
        }
    }
}
