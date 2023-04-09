using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace colle.Migrations
{
    public partial class ReplacePathWithContents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "path",
                table: "pastes",
                newName: "contents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "contents",
                table: "pastes",
                newName: "path");
        }
    }
}
