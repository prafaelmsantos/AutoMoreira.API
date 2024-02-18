using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoMoreira.Persistence.Migrations
{
    public partial class Migrations0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client_messages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<long>(type: "bigint", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    open = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client_messages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "marks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_default = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: true),
                    dark_mode = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    security_stamp = table.Column<string>(type: "text", nullable: false),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "visitors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    year = table.Column<int>(type: "integer", nullable: false),
                    month = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visitors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "models",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    mark_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_models", x => x.id);
                    table.ForeignKey(
                        name: "FK_models_marks_mark_id",
                        column: x => x.mark_id,
                        principalTable: "marks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identity_role_claim",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: false),
                    claim_value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identity_role_claim", x => x.id);
                    table.ForeignKey(
                        name: "FK_identity_role_claim_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identity_user_claim",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: false),
                    claim_value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identity_user_claim", x => x.id);
                    table.ForeignKey(
                        name: "FK_identity_user_claim_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identity_user_login",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identity_user_login", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "FK_identity_user_login_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identity_user_token",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identity_user_token", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "FK_identity_user_token_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_user_roles_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_roles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    model_id = table.Column<int>(type: "integer", nullable: false),
                    version = table.Column<string>(type: "text", nullable: true),
                    fuel_type = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    mileage = table.Column<double>(type: "double precision", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false),
                    doors = table.Column<int>(type: "integer", nullable: false),
                    transmission = table.Column<int>(type: "integer", nullable: false),
                    engine_size = table.Column<int>(type: "integer", nullable: false),
                    power = table.Column<int>(type: "integer", nullable: false),
                    observations = table.Column<string>(type: "text", nullable: true),
                    opportunity = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    sold = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    sold_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.id);
                    table.ForeignKey(
                        name: "FK_vehicles_models_model_id",
                        column: x => x.model_id,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_images",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    url = table.Column<string>(type: "text", nullable: false),
                    vehicleId = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_images", x => x.id);
                    table.ForeignKey(
                        name: "FK_vehicle_images_vehicles_vehicleId",
                        column: x => x.vehicleId,
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "marks",
                columns: new[] { "id", "created_date", "last_modified_date", "name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7211), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7217), "Audi" },
                    { 2, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7224), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7226), "Mercedes" },
                    { 3, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7228), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7229), "BMW" },
                    { 4, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7230), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7231), "Peugeot" },
                    { 5, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7233), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7233), "Volkswagen" },
                    { 6, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7235), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7236), "Citroën" },
                    { 7, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7237), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7239), "Renault" },
                    { 8, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7240), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7241), "Volvo" },
                    { 9, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7243), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7244), "Fiat" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "created_date", "is_default", "last_modified_date", "name", "normalized_name" },
                values: new object[] { 1, "7e35ec1e-eb17-418f-adbd-f88f5b13fcca", new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7769), true, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7771), "Administrador", null });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "created_date", "last_modified_date", "name", "normalized_name" },
                values: new object[] { 2, "4772c90e-2e3e-469a-abda-d48d35e90932", new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7781), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7782), "Colaborador", null });

            migrationBuilder.InsertData(
                table: "models",
                columns: new[] { "id", "created_date", "last_modified_date", "mark_id", "name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7596), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7597), 1, "A3" },
                    { 2, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7600), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7601), 2, "Classe A" },
                    { 3, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7602), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7603), 3, "Serie 1" },
                    { 4, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7605), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7605), 4, "308" },
                    { 5, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7607), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7608), 5, "Golf" },
                    { 6, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7609), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7610), 6, "C4" },
                    { 7, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7611), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7612), 7, "Megane" },
                    { 8, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7613), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7614), 8, "V40" },
                    { 9, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7616), new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7616), 9, "Punto" }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "color", "created_date", "doors", "engine_size", "fuel_type", "last_modified_date", "mileage", "model_id", "observations", "opportunity", "power", "price", "sold_date", "transmission", "version", "year" },
                values: new object[,]
                {
                    { 1, "Azul", new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7663), 5, 1999, 2, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7664), 20000.0, 1, "Garantia de 2 anos", true, 140, 20000.0, null, 1, "Sportline", 2020 },
                    { 2, "Cinza", new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7671), 5, 1999, 3, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7672), 20000.0, 2, "Garantia de 2 anos", true, 140, 20000.0, null, 2, "AMG", 2020 },
                    { 3, "Vermelho", new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7675), 5, 1999, 1, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7676), 20000.0, 3, "Garantia de 2 anos", true, 140, 20000.0, null, 2, "Sport", 2020 }
                });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "id", "color", "created_date", "doors", "engine_size", "fuel_type", "last_modified_date", "mileage", "model_id", "observations", "power", "price", "sold_date", "transmission", "version", "year" },
                values: new object[] { 4, "Verde", new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7679), 5, 1999, 1, new DateTime(2024, 2, 18, 17, 7, 31, 515, DateTimeKind.Utc).AddTicks(7680), 20000.0, 4, "Garantia de 2 anos", 140, 10000.0, null, 1, "GTI", 2020 });

            migrationBuilder.CreateIndex(
                name: "IX_identity_role_claim_role_id",
                table: "identity_role_claim",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_identity_user_claim_user_id",
                table: "identity_user_claim",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_identity_user_login_user_id",
                table: "identity_user_login",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_models_mark_id",
                table: "models",
                column: "mark_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "roles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_role_id",
                table: "user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "users",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "users",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_images_vehicleId",
                table: "vehicle_images",
                column: "vehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_model_id",
                table: "vehicles",
                column: "model_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client_messages");

            migrationBuilder.DropTable(
                name: "identity_role_claim");

            migrationBuilder.DropTable(
                name: "identity_user_claim");

            migrationBuilder.DropTable(
                name: "identity_user_login");

            migrationBuilder.DropTable(
                name: "identity_user_token");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "vehicle_images");

            migrationBuilder.DropTable(
                name: "visitors");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "models");

            migrationBuilder.DropTable(
                name: "marks");
        }
    }
}
