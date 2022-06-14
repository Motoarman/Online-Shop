using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Model.Migrations
{
    public partial class model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Orders__Purchase__2B3F6F97",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK__PurchaceI__Produ__267ABA7A",
                table: "PurchaceItem");

            migrationBuilder.AddColumn<int>(
                name: "Category_id",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category_id",
                table: "Product",
                column: "Category_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__Purchase__47DBAE45",
                table: "Orders",
                column: "PurchaseItem_Id",
                principalTable: "PurchaceItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Product__Categor__4222D4EF",
                table: "Product",
                column: "Category_id",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__PurchaceI__Produ__44FF419A",
                table: "PurchaceItem",
                column: "Product_Id",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Orders__Purchase__47DBAE45",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK__Product__Categor__4222D4EF",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK__PurchaceI__Produ__44FF419A",
                table: "PurchaceItem");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Product_Category_id",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Category_id",
                table: "Product");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__Purchase__2B3F6F97",
                table: "Orders",
                column: "PurchaseItem_Id",
                principalTable: "PurchaceItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__PurchaceI__Produ__267ABA7A",
                table: "PurchaceItem",
                column: "Product_Id",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
