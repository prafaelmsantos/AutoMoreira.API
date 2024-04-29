using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoMoreira.Persistence.Migrations
{
    public partial class Migration000002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "mileage",
                table: "vehicles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<string>(
                name: "color",
                table: "vehicles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "c6e7d6e7-1054-4532-aa1d-731367cfea4e");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "e0cb6193-d91e-41ee-b6fd-a14140803f86");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "password_hash", "security_stamp" },
                values: new object[] { "b7bf37a7-e413-4691-8d83-306dbbd09338", "AQAAAAEAACcQAAAAEGqZx+fdFcb52kS59k56xWYQ5HhSnEMp7QhbwwkRmxOOuBZ1HR9j7bk0t/KSqWEqmQ==", "349c84bd-0ea4-47e3-89d2-e4a951d2c905" });

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "id",
                keyValue: 1,
                column: "mileage",
                value: 2000);

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "id",
                keyValue: 2,
                column: "mileage",
                value: 7000);

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "id",
                keyValue: 3,
                column: "mileage",
                value: 0);

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "id",
                keyValue: 4,
                column: "mileage",
                value: 10000);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "mileage",
                table: "vehicles",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "color",
                table: "vehicles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "id",
                keyValue: 1,
                column: "mileage",
                value: 2000.0);

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "id",
                keyValue: 2,
                column: "mileage",
                value: 7000.0);

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "id",
                keyValue: 3,
                column: "mileage",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "id",
                keyValue: 4,
                column: "mileage",
                value: 10000.0);
        }
    }
}
