using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CiberWeb.Migrations
{
    public partial class createrecorddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5b900f33-7b27-4dc0-b796-dc867f74a3b4"),
                column: "ConcurrencyStamp",
                value: "5e50763d-6603-4b99-8007-8bf2598f85f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "cfc6586f-eb88-4b64-8071-796935ed43fa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e7baa66a-a749-49ac-8a71-7ae946aa2659", "AQAAAAEAACcQAAAAEMWB478jDQRlaVDaSzAzy500K+L2+cyJJfd1FWTEdj2MmiEkBBgnoveZcl4U2GMktA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                column: "Name",
                value: "Man shirt 2");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryId", "Description", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 6, 3, null, "Jean 1", 100000m, 100 },
                    { 7, 3, null, "Jean 2", 100000m, 100 },
                    { 8, 4, null, "Shorts 1", 100000m, 100 },
                    { 9, 4, null, "Shorts 2", 100000m, 100 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5b900f33-7b27-4dc0-b796-dc867f74a3b4"),
                column: "ConcurrencyStamp",
                value: "fc2e71e0-5acc-48d2-9222-6fce00480849");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "390daad9-c01a-4a8a-ad03-de5f03f799bf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a93c6b7c-5026-4d5d-8ed1-8a55a7da9019", "AQAAAAEAACcQAAAAEGNtquKq6qHHPbjAcrnYEjRhYwPh19zwhl0qBTw18wdC9Ss/5UYZ0HDTYnjpZeUxAQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                column: "Name",
                value: "Man shirt 1");
        }
    }
}
