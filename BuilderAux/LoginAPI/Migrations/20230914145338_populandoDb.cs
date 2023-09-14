using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LoginAPI.Migrations
{
    /// <inheritdoc />
    public partial class populandoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DataAtualizacao", "DataCadastro", "Email", "Nome", "Password", "Phone" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 9, 14, 11, 53, 38, 95, DateTimeKind.Local).AddTicks(1999), "igorpaimdeoliveira@gmail.com", "Igor Paim de Oliveira", "password", "71999434958" },
                    { 2, null, new DateTime(2023, 9, 14, 11, 53, 38, 95, DateTimeKind.Local).AddTicks(2026), "Rogeriodeoliveira@gmail.com", "Rogerio Oliveira", "password", "71999434958" },
                    { 3, null, new DateTime(2023, 9, 14, 11, 53, 38, 95, DateTimeKind.Local).AddTicks(2033), "Magnopaim@gmail.com", "Magno Paim", "password", "71999434958" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
