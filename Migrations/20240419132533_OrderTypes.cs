using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace hhpw_be.Migrations
{
    public partial class OrderTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OrderType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Walk-in" },
                    { 2, "Call-in" },
                    { 3, "Mobile" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateClosed",
                value: new DateTime(2024, 4, 19, 8, 25, 33, 282, DateTimeKind.Local).AddTicks(6711));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateClosed",
                value: new DateTime(2024, 4, 19, 8, 25, 33, 282, DateTimeKind.Local).AddTicks(6757));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderType");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateClosed",
                value: new DateTime(2024, 4, 15, 19, 51, 51, 516, DateTimeKind.Local).AddTicks(5750));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateClosed",
                value: new DateTime(2024, 4, 15, 19, 51, 51, 516, DateTimeKind.Local).AddTicks(5803));
        }
    }
}
