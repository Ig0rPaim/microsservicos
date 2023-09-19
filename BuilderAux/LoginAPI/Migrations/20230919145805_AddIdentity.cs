using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2023, 9, 19, 11, 58, 5, 877, DateTimeKind.Local).AddTicks(1840));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2023, 9, 19, 11, 58, 5, 877, DateTimeKind.Local).AddTicks(1866));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2023, 9, 19, 11, 58, 5, 877, DateTimeKind.Local).AddTicks(1874));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2023, 9, 14, 11, 53, 38, 95, DateTimeKind.Local).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2023, 9, 14, 11, 53, 38, 95, DateTimeKind.Local).AddTicks(2026));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2023, 9, 14, 11, 53, 38, 95, DateTimeKind.Local).AddTicks(2033));
        }
    }
}
