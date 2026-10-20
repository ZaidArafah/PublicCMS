using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicCMS.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddedReportedPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "content",
                table: "PrivateMessages",
                newName: "Content");

            migrationBuilder.CreateTable(
                name: "ReportedPosts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForumPostId = table.Column<int>(type: "int", nullable: false),
                    ReportedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportedPosts", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportedPosts");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "PrivateMessages",
                newName: "content");
        }
    }
}
