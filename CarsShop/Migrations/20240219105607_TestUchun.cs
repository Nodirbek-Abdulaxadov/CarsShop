using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsShop.Migrations
{
    /// <inheritdoc />
    public partial class TestUchun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nimadir",
                table: "Brends",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nimadir",
                table: "Brends");
        }
    }
}
