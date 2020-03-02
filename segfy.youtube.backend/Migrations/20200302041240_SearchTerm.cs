using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace segfy.youtube.backend.Migrations
{
    public partial class SearchTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SearchedAt",
                table: "SearchLogs");

            migrationBuilder.AddColumn<int>(
                name: "SearchTermId",
                table: "SearchLogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SearchTerm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Term = table.Column<string>(nullable: true),
                    SearchedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchTerm", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SearchLogs_SearchTermId",
                table: "SearchLogs",
                column: "SearchTermId");

            migrationBuilder.AddForeignKey(
                name: "FK_SearchLogs_SearchTerm_SearchTermId",
                table: "SearchLogs",
                column: "SearchTermId",
                principalTable: "SearchTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SearchLogs_SearchTerm_SearchTermId",
                table: "SearchLogs");

            migrationBuilder.DropTable(
                name: "SearchTerm");

            migrationBuilder.DropIndex(
                name: "IX_SearchLogs_SearchTermId",
                table: "SearchLogs");

            migrationBuilder.DropColumn(
                name: "SearchTermId",
                table: "SearchLogs");

            migrationBuilder.AddColumn<DateTime>(
                name: "SearchedAt",
                table: "SearchLogs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
