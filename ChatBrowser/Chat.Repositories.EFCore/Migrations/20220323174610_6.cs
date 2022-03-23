using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chat.Repositories.EFCore.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 23, 11, 46, 10, 509, DateTimeKind.Local).AddTicks(2867));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 23, 11, 46, 10, 510, DateTimeKind.Local).AddTicks(3351));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2022, 3, 23, 11, 46, 10, 511, DateTimeKind.Local).AddTicks(4294), "cadaefedfef59f3b2eadd7147d4b6891" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2022, 3, 23, 11, 46, 10, 511, DateTimeKind.Local).AddTicks(5442), "cadaefedfef59f3b2eadd7147d4b6891" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 21, 21, 30, 7, 835, DateTimeKind.Local).AddTicks(7125));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 21, 21, 30, 7, 838, DateTimeKind.Local).AddTicks(6836));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 30, 7, 839, DateTimeKind.Local).AddTicks(9694), "byronpenna123" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 30, 7, 840, DateTimeKind.Local).AddTicks(879), "diana123" });
        }
    }
}
