using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Work_Libreria.Migrations
{
    /// <inheritdoc />
    public partial class modifynameoftable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchaseDatas_Book_PurchasedBookId",
                table: "purchaseDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_purchaseDatas",
                table: "purchaseDatas");

            migrationBuilder.RenameTable(
                name: "purchaseDatas",
                newName: "PurchaseDatas");

            migrationBuilder.RenameIndex(
                name: "IX_purchaseDatas_PurchasedBookId",
                table: "PurchaseDatas",
                newName: "IX_PurchaseDatas_PurchasedBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseDatas",
                table: "PurchaseDatas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDatas_Book_PurchasedBookId",
                table: "PurchaseDatas",
                column: "PurchasedBookId",
                principalTable: "Book",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDatas_Book_PurchasedBookId",
                table: "PurchaseDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseDatas",
                table: "PurchaseDatas");

            migrationBuilder.RenameTable(
                name: "PurchaseDatas",
                newName: "purchaseDatas");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseDatas_PurchasedBookId",
                table: "purchaseDatas",
                newName: "IX_purchaseDatas_PurchasedBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_purchaseDatas",
                table: "purchaseDatas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseDatas_Book_PurchasedBookId",
                table: "purchaseDatas",
                column: "PurchasedBookId",
                principalTable: "Book",
                principalColumn: "Id");
        }
    }
}
