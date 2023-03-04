using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CiberWeb.Migrations
{
    public partial class correctDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5b900f33-7b27-4dc0-b796-dc867f74a3b4"),
                column: "ConcurrencyStamp",
                value: "32ae85e9-f39c-437f-b612-e8c2f994e787");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "a017d9a7-7ba0-4b36-8b4e-98ff1eea83a3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b898051a-1ce8-4575-8e53-26fbd200f47f", "AQAAAAEAACcQAAAAEA1Ygm8p7TtaFZwZ5Vg1qX+I/vv0lWRmiBRGCZ3oa18AzUI8BCLsatsMJncpUSkL2A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5b900f33-7b27-4dc0-b796-dc867f74a3b4"),
                column: "ConcurrencyStamp",
                value: "42a6ff4a-7e22-4724-a7a3-709563d96077");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "04146d6e-c1ef-49e6-8aac-abea428448bc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d528bdf4-149e-45f6-80f6-a241572d716b", "AQAAAAEAACcQAAAAEC1rinf6Lnt+TKC4d8O7h2qLfB6ZRQlD2Ipc2uEpSHh1roiCEfMFjLNUvJ5hFjl0MA==" });
        }
    }
}
