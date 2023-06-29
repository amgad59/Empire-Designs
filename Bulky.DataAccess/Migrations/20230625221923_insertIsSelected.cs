﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class insertIsSelected : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isSelected",
                table: "ProductSizes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "isSelected",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "isSelected",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "isSelected",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSelected",
                table: "ProductSizes");
        }
    }
}