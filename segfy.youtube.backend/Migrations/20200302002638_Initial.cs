using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace segfy.youtube.backend.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VideoId = table.Column<string>(nullable: true),
                    ChannelId = table.Column<string>(nullable: true),
                    ChannelTitle = table.Column<string>(nullable: true),
                    VideoTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Thumbnails = table.Column<string>(nullable: true),
                    PublishedAt = table.Column<DateTime>(nullable: true),
                    SearchedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchLogs");
        }
    }
}
