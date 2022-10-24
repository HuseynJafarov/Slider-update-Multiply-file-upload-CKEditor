using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkProject.Migrations
{
    public partial class CreatePhotoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SignImage",
                table: "SliderDetails");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "SliderDetails",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 10, 25, 2, 46, 42, 889, DateTimeKind.Local).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 10, 25, 2, 46, 42, 891, DateTimeKind.Local).AddTicks(2841));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 10, 25, 2, 46, 42, 891, DateTimeKind.Local).AddTicks(2890));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "SliderDetails");

            migrationBuilder.AddColumn<string>(
                name: "SignImage",
                table: "SliderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 10, 24, 13, 6, 5, 189, DateTimeKind.Local).AddTicks(6996));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 10, 24, 13, 6, 5, 191, DateTimeKind.Local).AddTicks(9941));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 10, 24, 13, 6, 5, 192, DateTimeKind.Local).AddTicks(136));
        }
    }
}
