using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Neat.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesAndConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category_name",
                table: "tbl_assets");

            migrationBuilder.CreateTable(
                name: "tbl_asset_types",
                columns: table => new
                {
                    asset_type_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_asset_types", x => x.asset_type_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_conditions",
                columns: table => new
                {
                    condition_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    condition_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_conditions", x => x.condition_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_locations",
                columns: table => new
                {
                    location_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_locations", x => x.location_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_statuses",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_statuses", x => x.status_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_assets_asset_type_id",
                table: "tbl_assets",
                column: "asset_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_assets_current_condition_id",
                table: "tbl_assets",
                column: "current_condition_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_assets_location_id",
                table: "tbl_assets",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_assets_status_id",
                table: "tbl_assets",
                column: "status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_assets_tbl_asset_types_asset_type_id",
                table: "tbl_assets",
                column: "asset_type_id",
                principalTable: "tbl_asset_types",
                principalColumn: "asset_type_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_assets_tbl_conditions_current_condition_id",
                table: "tbl_assets",
                column: "current_condition_id",
                principalTable: "tbl_conditions",
                principalColumn: "condition_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_assets_tbl_locations_location_id",
                table: "tbl_assets",
                column: "location_id",
                principalTable: "tbl_locations",
                principalColumn: "location_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_assets_tbl_statuses_status_id",
                table: "tbl_assets",
                column: "status_id",
                principalTable: "tbl_statuses",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_assets_tbl_asset_types_asset_type_id",
                table: "tbl_assets");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_assets_tbl_conditions_current_condition_id",
                table: "tbl_assets");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_assets_tbl_locations_location_id",
                table: "tbl_assets");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_assets_tbl_statuses_status_id",
                table: "tbl_assets");

            migrationBuilder.DropTable(
                name: "tbl_asset_types");

            migrationBuilder.DropTable(
                name: "tbl_conditions");

            migrationBuilder.DropTable(
                name: "tbl_locations");

            migrationBuilder.DropTable(
                name: "tbl_statuses");

            migrationBuilder.DropIndex(
                name: "IX_tbl_assets_asset_type_id",
                table: "tbl_assets");

            migrationBuilder.DropIndex(
                name: "IX_tbl_assets_current_condition_id",
                table: "tbl_assets");

            migrationBuilder.DropIndex(
                name: "IX_tbl_assets_location_id",
                table: "tbl_assets");

            migrationBuilder.DropIndex(
                name: "IX_tbl_assets_status_id",
                table: "tbl_assets");

            migrationBuilder.AddColumn<string>(
                name: "category_name",
                table: "tbl_assets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
