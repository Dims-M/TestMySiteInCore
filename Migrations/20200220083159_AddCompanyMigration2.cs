using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCompany.Migrations
{
    public partial class AddCompanyMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "b7544205-175d-46c2-902d-c7e184b5563d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7438b35c-cca3-4ec5-aadb-17421c8f4a8c", "AQAAAAEAACcQAAAAEDhYeTqcrqFfKx5X6sO9besUscQUcdh2jEwElNpzqeZkBWezSFHbDkGQfuEL30xqEA==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2020, 2, 20, 8, 31, 58, 822, DateTimeKind.Utc).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2020, 2, 20, 8, 31, 58, 822, DateTimeKind.Utc).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2020, 2, 20, 8, 31, 58, 822, DateTimeKind.Utc).AddTicks(8267));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "172714b4-c0ab-4a22-b1d7-e4350d919b51");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "27881034-9a4c-4be8-a0b1-d24c87509dfc", "AQAAAAEAACcQAAAAEAwjHmemdItzg5cEUANwm/HVpVW4k8xnBTVaTtAv9wrrR9HKA9MgoVMqVDicaVWeSw==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2020, 2, 17, 14, 4, 8, 119, DateTimeKind.Utc).AddTicks(5091));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2020, 2, 17, 14, 4, 8, 119, DateTimeKind.Utc).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2020, 2, 17, 14, 4, 8, 119, DateTimeKind.Utc).AddTicks(5036));
        }
    }
}
