using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Work_Libreria.Migrations
{
    /// <inheritdoc />
    public partial class addedAdminPurchaseData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "SupplierPrice",
                table: "Book",
                type: "real",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdminPurchaseDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PurchasedBookId = table.Column<int>(type: "int", nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchasePrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminPurchaseDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminPurchaseDatas_Book_PurchasedBookId",
                        column: x => x.PurchasedBookId,
                        principalTable: "Book",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminPurchaseDatas_PurchasedBookId",
                table: "AdminPurchaseDatas",
                column: "PurchasedBookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminPurchaseDatas");

            migrationBuilder.DropColumn(
                name: "SupplierPrice",
                table: "Book");
        }
    }
}
