using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Work_Libreria.Migrations
{
    /// <inheritdoc />
    public partial class addedLikeRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminPurchaseDatas_Book_PurchasedBookId",
                table: "AdminPurchaseDatas");

            migrationBuilder.AlterColumn<int>(
                name: "PurchasedBookId",
                table: "AdminPurchaseDatas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Like_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Like_BookId",
                table: "Like",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminPurchaseDatas_Book_PurchasedBookId",
                table: "AdminPurchaseDatas",
                column: "PurchasedBookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminPurchaseDatas_Book_PurchasedBookId",
                table: "AdminPurchaseDatas");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.AlterColumn<int>(
                name: "PurchasedBookId",
                table: "AdminPurchaseDatas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminPurchaseDatas_Book_PurchasedBookId",
                table: "AdminPurchaseDatas",
                column: "PurchasedBookId",
                principalTable: "Book",
                principalColumn: "Id");
        }
    }
}
