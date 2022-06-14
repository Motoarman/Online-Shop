using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Model.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Discription = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaceItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Id = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PurchaceI__Produ__267ABA7A",
                        column: x => x.Product_Id,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseItem_Id = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Orders__Purchase__2B3F6F97",
                        column: x => x.PurchaseItem_Id,
                        principalTable: "PurchaceItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PurchaseItem_Id",
                table: "Orders",
                column: "PurchaseItem_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaceItem_Product_Id",
                table: "PurchaceItem",
                column: "Product_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PurchaceItem");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
