using Microsoft.EntityFrameworkCore.Migrations;

namespace DepositoDepositaMais.Infrastructure.Persistence.Migrations
{
    public partial class MigrationAddColumnStatusInCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "StorageLocation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "StorageLocation");
        }
    }
}
