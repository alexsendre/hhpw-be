using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hhpw_be.Migrations
{
    public partial class OrderTypesInContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderType",
                table: "OrderType");

            migrationBuilder.DropColumn(
                name: "OrderType",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "OrderType",
                newName: "OrderTypes");

            migrationBuilder.AddColumn<int>(
                name: "OrderTypeId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderTypes",
                table: "OrderTypes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateClosed", "OrderTypeId" },
                values: new object[] { new DateTime(2024, 4, 19, 8, 41, 31, 388, DateTimeKind.Local).AddTicks(7791), 2 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateClosed", "OrderTypeId" },
                values: new object[] { new DateTime(2024, 4, 19, 8, 41, 31, 388, DateTimeKind.Local).AddTicks(7844), 3 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderTypeId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_OrderTypes_OrderId",
                table: "OrderTypes",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTypes_Orders_OrderId",
                table: "OrderTypes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderTypes_Orders_OrderId",
                table: "OrderTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderTypes",
                table: "OrderTypes");

            migrationBuilder.DropIndex(
                name: "IX_OrderTypes_OrderId",
                table: "OrderTypes");

            migrationBuilder.DropColumn(
                name: "OrderTypeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderTypes");

            migrationBuilder.RenameTable(
                name: "OrderTypes",
                newName: "OrderType");

            migrationBuilder.AddColumn<string>(
                name: "OrderType",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderType",
                table: "OrderType",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateClosed", "OrderType" },
                values: new object[] { new DateTime(2024, 4, 19, 8, 25, 33, 282, DateTimeKind.Local).AddTicks(6711), "Walk In" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderType",
                value: "Call In");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateClosed", "OrderType" },
                values: new object[] { new DateTime(2024, 4, 19, 8, 25, 33, 282, DateTimeKind.Local).AddTicks(6757), "Mobile" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderType",
                value: "Call In");
        }
    }
}
