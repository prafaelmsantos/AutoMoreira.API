using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoMoreira.Persistence.Migrations
{
    public partial class migration02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_role_role_RoleId",
                table: "user_role");

            migrationBuilder.DropForeignKey(
                name: "FK_user_role_user_UserId",
                table: "user_role");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "user_role",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_role",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_role_RoleId",
                table: "user_role",
                newName: "IX_user_role_role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_role_role_role_id",
                table: "user_role",
                column: "role_id",
                principalTable: "role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_role_user_user_id",
                table: "user_role",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_role_role_role_id",
                table: "user_role");

            migrationBuilder.DropForeignKey(
                name: "FK_user_role_user_user_id",
                table: "user_role");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "user_role",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "user_role",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_user_role_role_id",
                table: "user_role",
                newName: "IX_user_role_RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_role_role_RoleId",
                table: "user_role",
                column: "RoleId",
                principalTable: "role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_role_user_UserId",
                table: "user_role",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
