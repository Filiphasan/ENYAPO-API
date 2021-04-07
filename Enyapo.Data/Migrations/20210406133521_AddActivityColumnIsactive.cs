using Microsoft.EntityFrameworkCore.Migrations;

namespace Enyapo.Data.Migrations
{
    public partial class AddActivityColumnIsactive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Activities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Activities");
        }
    }
}
