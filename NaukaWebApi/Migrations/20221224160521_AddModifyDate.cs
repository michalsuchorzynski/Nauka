using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaukaWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddModifyDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Phones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "PersonCompanies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "People",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Passports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "PersonCompanies");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Passports");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Companies");
        }
    }
}
