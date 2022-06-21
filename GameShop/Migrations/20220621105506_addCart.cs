using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameShop.Migrations
{
    public partial class addCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopCart",
                columns: table => new
                {
                    ShopCartId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCart", x => x.ShopCartId);
                    table.ForeignKey(
                        name: "FK_ShopCart_MyUser_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "MyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopCartItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PAmount = table.Column<int>(type: "int", nullable: false),
                    ShopCartId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopCartItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopCartItem_ShopCart_ShopCartId",
                        column: x => x.ShopCartId,
                        principalTable: "ShopCart",
                        principalColumn: "ShopCartId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopCart_CustomerId",
                table: "ShopCart",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartItem_ProductId",
                table: "ShopCartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartItem_ShopCartId",
                table: "ShopCartItem",
                column: "ShopCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopCartItem");

            migrationBuilder.DropTable(
                name: "ShopCart");
        }
    }
}
