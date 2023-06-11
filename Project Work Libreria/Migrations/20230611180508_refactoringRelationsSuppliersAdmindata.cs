using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Work_Libreria.Migrations
{
    /// <inheritdoc />
    public partial class refactoringRelationsSuppliersAdmindata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_AdminPurchaseDatas_AdminPurchaseDataId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_AdminPurchaseDataId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "AdminPurchaseDataId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "AdminPurchaseDatas");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "AdminPurchaseDatas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdminPurchaseDatas_SupplierId",
                table: "AdminPurchaseDatas",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminPurchaseDatas_Supplier_SupplierId",
                table: "AdminPurchaseDatas",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminPurchaseDatas_Supplier_SupplierId",
                table: "AdminPurchaseDatas");

            migrationBuilder.DropIndex(
                name: "IX_AdminPurchaseDatas_SupplierId",
                table: "AdminPurchaseDatas");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "AdminPurchaseDatas");

            migrationBuilder.AddColumn<int>(
                name: "AdminPurchaseDataId",
                table: "Supplier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "AdminPurchaseDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_AdminPurchaseDataId",
                table: "Supplier",
                column: "AdminPurchaseDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_AdminPurchaseDatas_AdminPurchaseDataId",
                table: "Supplier",
                column: "AdminPurchaseDataId",
                principalTable: "AdminPurchaseDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
