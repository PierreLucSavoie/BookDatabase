using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookDatabase.Data.Migrations
{
    public partial class modifiedBookAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Whishlist",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Whishlist",
                table: "Books");
        }
    }
}
