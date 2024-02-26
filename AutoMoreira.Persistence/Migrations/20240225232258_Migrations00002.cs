using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoMoreira.Persistence.Migrations
{
    public partial class Migrations00002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_images_vehicles_vehicleId",
                table: "vehicle_images");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_images_vehicles_vehicleId",
                table: "vehicle_images");

            migrationBuilder.UpdateData(
                table: "marks",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2422), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2429) });

            migrationBuilder.UpdateData(
                table: "marks",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2433), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2434) });

            migrationBuilder.UpdateData(
                table: "marks",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2435), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2435) });

            migrationBuilder.UpdateData(
                table: "marks",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2436), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2436) });

            migrationBuilder.UpdateData(
                table: "marks",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2437), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2437) });

            migrationBuilder.UpdateData(
                table: "marks",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2438), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2438) });

            migrationBuilder.UpdateData(
                table: "marks",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2439), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2439) });

            migrationBuilder.UpdateData(
                table: "marks",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2440), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2440) });

            migrationBuilder.UpdateData(
                table: "marks",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2441), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2441) });

            migrationBuilder.UpdateData(
                table: "models",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2574), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2575) });

            migrationBuilder.UpdateData(
                table: "models",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2575), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2576) });

            migrationBuilder.UpdateData(
                table: "models",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2577), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2577) });

            migrationBuilder.UpdateData(
                table: "models",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2577), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2578) });

            migrationBuilder.UpdateData(
                table: "models",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2578), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2579) });

            migrationBuilder.UpdateData(
                table: "models",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2579), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2580) });

            migrationBuilder.UpdateData(
                table: "models",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2580), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2580) });

            migrationBuilder.UpdateData(
                table: "models",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2581), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2581) });

            migrationBuilder.UpdateData(
                table: "models",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2582), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2583) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "created_date", "last_modified_date" },
                values: new object[] { "4ea18120-b0d4-4831-acaa-746b5113a82a", new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2662), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2663) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "concurrency_stamp", "created_date", "last_modified_date" },
                values: new object[] { "02a26881-2789-4229-ae90-ddfa9ba6a15f", new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2669), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2670) });

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2603), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2603) });

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2608), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2608) });

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2609), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2610) });

            migrationBuilder.UpdateData(
                table: "vehicles",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_date", "last_modified_date" },
                values: new object[] { new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2611), new DateTime(2024, 2, 24, 1, 1, 30, 388, DateTimeKind.Utc).AddTicks(2611) });

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_images_vehicles_vehicleId",
                table: "vehicle_images",
                column: "vehicleId",
                principalTable: "vehicles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
