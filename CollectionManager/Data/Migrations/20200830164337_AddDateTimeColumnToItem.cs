using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CollectionManager.Data.Migrations
{
    public partial class AddDateTimeColumnToItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddingTime",
                table: "Items",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddingTime",
                table: "Items");
        }
    }
}
