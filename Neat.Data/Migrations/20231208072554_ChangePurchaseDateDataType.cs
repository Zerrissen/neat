using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Neat.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangePurchaseDateDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "purchase_date",
                table: "tbl_assets",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "purchase_date",
                table: "tbl_assets",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
