using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace colle.Migrations
{
    public partial class CreatePastes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pastes",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    checksum = table.Column<string>(type: "text", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pastes", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_pastes_checksum",
                table: "pastes",
                column: "checksum",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pastes");
        }
    }
}
