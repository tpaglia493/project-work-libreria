using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Work_Libreria.Migrations
{
    /// <inheritdoc />
    public partial class addedLikeQuantityToBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LikeQuantity",
                table: "Book",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeQuantity",
                table: "Book");
        }
    }
}
