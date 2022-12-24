using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaukaWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ManyOneToManyRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passport_People_PersonId",
                table: "Passport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passport",
                table: "Passport");

            migrationBuilder.RenameTable(
                name: "Passport",
                newName: "Passports");

            migrationBuilder.RenameColumn(
                name: "PassportId",
                table: "Passports",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Passport_PersonId",
                table: "Passports",
                newName: "IX_Passports_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passports",
                table: "Passports",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonCompanies",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonCompanies", x => new { x.PersonId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_PersonCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonCompanies_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonCompanies_CompanyId",
                table: "PersonCompanies",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passports_People_PersonId",
                table: "Passports",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passports_People_PersonId",
                table: "Passports");

            migrationBuilder.DropTable(
                name: "PersonCompanies");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passports",
                table: "Passports");

            migrationBuilder.RenameTable(
                name: "Passports",
                newName: "Passport");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Passport",
                newName: "PassportId");

            migrationBuilder.RenameIndex(
                name: "IX_Passports_PersonId",
                table: "Passport",
                newName: "IX_Passport_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passport",
                table: "Passport",
                column: "PassportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passport_People_PersonId",
                table: "Passport",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
