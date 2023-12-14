using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Neat.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixLocationColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status_name",
                table: "tbl_locations",
                newName: "location_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "location_name",
                table: "tbl_locations",
                newName: "status_name");
        }
    }
}
