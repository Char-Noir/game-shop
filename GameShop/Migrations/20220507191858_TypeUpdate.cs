using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameShop.Migrations
{
    public partial class TypeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Type_Product_ProductId",
                table: "Product_Type");

            migrationBuilder.DropIndex(
                name: "IX_Product_Type_ProductId",
                table: "Product_Type");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Product_Type");

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Product_TypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductType_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductType_Product_Type_Product_TypeId",
                        column: x => x.Product_TypeId,
                        principalTable: "Product_Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_Product_TypeId",
                table: "ProductType",
                column: "Product_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_ProductId",
                table: "ProductType",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "Product_Type",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Type_ProductId",
                table: "Product_Type",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Type_Product_ProductId",
                table: "Product_Type",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
