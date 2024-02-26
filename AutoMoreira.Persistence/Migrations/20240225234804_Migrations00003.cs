using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoMoreira.Persistence.Migrations
{
    public partial class Migrations00003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_images_vehicles_vehicleId",
                table: "vehicle_images");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "last_modified_date",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "vehicle_images");

            migrationBuilder.DropColumn(
                name: "last_modified_date",
                table: "vehicle_images");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "users");

            migrationBuilder.DropColumn(
                name: "last_modified_date",
                table: "users");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "last_modified_date",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "models");

            migrationBuilder.DropColumn(
                name: "last_modified_date",
                table: "models");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "marks");

            migrationBuilder.DropColumn(
                name: "last_modified_date",
                table: "marks");

            migrationBuilder.DropColumn(
                name: "last_modified_date",
                table: "client_messages");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "9f85cd60-413e-495c-8d39-396dcb9e2354");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "183b37b6-f1f5-466e-8a9b-93cc11b789a8");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_images_vehicles_vehicleId",
                table: "vehicle_images",
                column: "vehicleId",
                principalTable: "vehicles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_images_vehicles_vehicleId",
                table: "vehicle_images");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "vehicles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_date",
                table: "vehicles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "vehicle_images",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_date",
                table: "vehicle_images",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "roles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_date",
                table: "roles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "models",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_date",
                table: "models",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "marks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_date",
                table: "marks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_date",
                table: "client_messages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "marks",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6469), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6476) });

            migrationBuilder.UpdateData(
                table: "marks",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6480), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6480) });

            migrationBuilder.UpdateData(
                table: "marks",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6481), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6482) });

            migrationBuilder.UpdateData(
                table: "marks",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6482), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6483) });

            migrationBuilder.UpdateData(
                table: "marks",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6484), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6484) });

            migrationBuilder.UpdateData(
                table: "marks",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6485), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6485) });

            migrationBuilder.UpdateData(
                table: "marks",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6486), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6486) });

            migrationBuilder.UpdateData(
                table: "marks",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6487), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6487) });

            migrationBuilder.UpdateData(
                table: "marks",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6488), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6488) });

            migrationBuilder.UpdateData(
                table: "models",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6605), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6606) });

            migrationBuilder.UpdateData(
                table: "models",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6607), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6607) });

            migrationBuilder.UpdateData(
                table: "models",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6608), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6608) });

            migrationBuilder.UpdateData(
                table: "models",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6609), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6609) });

            migrationBuilder.UpdateData(
                table: "models",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6610), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "models",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6611), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6612) });

            migrationBuilder.UpdateData(
                table: "models",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6612), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6613) });

            migrationBuilder.UpdateData(
                table: "models",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6613), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6613) });

            migrationBuilder.UpdateData(
                table: "models",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6614), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6614) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "created_date", "last_modified_date" },
                values: new object[] { "fe186912-4ac8-4686-b829-d380267f6b1f", new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6690), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6691) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "concurrency_stamp", "created_date", "last_modified_date" },
                values: new object[] { "8e91a935-842c-4f3b-9c93-f63b4e416161", new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6699), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6700) });

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6634), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6634) });

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6638), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6638) });

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6640), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6640) });

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6641), new DateTime(2024, 2, 25, 23, 22, 57, 556, DateTimeKind.Utc).AddTicks(6641) });

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_images_vehicles_vehicleId",
                table: "vehicle_images",
                column: "vehicleId",
                principalTable: "vehicles",
                principalColumn: "id");
        }
    }
}
