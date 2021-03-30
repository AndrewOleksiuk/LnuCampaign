using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LnuCampaign.DAL.Migrations
{
    public partial class migr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("efcef2b3-8fae-45f1-8452-97c26292226b"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("986d8317-ed04-464a-921c-c3866a488566"),
                column: "NormalizedName",
                value: "USER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("986d8317-ed04-464a-921c-c3866a488566"),
                column: "NormalizedName",
                value: "STUDENT");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("efcef2b3-8fae-45f1-8452-97c26292226b"), "23bde7c8-43f6-47c6-8614-89c610f3f9e9", "Teacher", "TEACHER" });
        }
    }
}
