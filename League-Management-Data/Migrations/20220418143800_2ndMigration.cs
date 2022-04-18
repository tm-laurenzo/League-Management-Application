using Microsoft.EntityFrameworkCore.Migrations;

namespace League_Management_Data.Migrations
{
    public partial class _2ndMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valaution",
                table: "Teams",
                newName: "Valuation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valuation",
                table: "Teams",
                newName: "Valaution");
        }
    }
}
