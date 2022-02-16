using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Data.Migrations
{
    public partial class addProTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 16, 18, 59, 41, 587, DateTimeKind.Utc).AddTicks(6904),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 16, 6, 53, 0, 254, DateTimeKind.Utc).AddTicks(2911));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 16, 6, 53, 0, 254, DateTimeKind.Utc).AddTicks(2911),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 2, 16, 18, 59, 41, 587, DateTimeKind.Utc).AddTicks(6904));
        }
    }
}
