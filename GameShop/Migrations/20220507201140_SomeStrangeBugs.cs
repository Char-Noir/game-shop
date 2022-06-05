using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameShop.Migrations
{
    public partial class SomeStrangeBugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductType_Product_ProductId",
                table: "ProductType");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductType_Product_Type_Product_TypeId",
                table: "ProductType");

            migrationBuilder.DropIndex(
                name: "IX_ProductType_Product_TypeId",
                table: "ProductType");

            migrationBuilder.DropIndex(
                name: "IX_ProductType_ProductId",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "Product_TypeId",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Product_Type");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "Product_Type",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Product_TypeId",
                table: "Product_Type",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Type_Product_TypeId",
                table: "Product_Type",
                column: "Product_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Type_ProductId",
                table: "Product_Type",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Type_Product_ProductId",
                table: "Product_Type",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Type_ProductType_Product_TypeId",
                table: "Product_Type",
                column: "Product_TypeId",
                principalTable: "ProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Type_Product_ProductId",
                table: "Product_Type");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Type_ProductType_Product_TypeId",
                table: "Product_Type");

            migrationBuilder.DropIndex(
                name: "IX_Product_Type_Product_TypeId",
                table: "Product_Type");

            migrationBuilder.DropIndex(
                name: "IX_Product_Type_ProductId",
                table: "Product_Type");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Product_Type");

            migrationBuilder.DropColumn(
                name: "Product_TypeId",
                table: "Product_Type");

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "ProductType",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Product_TypeId",
                table: "ProductType",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Product_Type",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_Product_TypeId",
                table: "ProductType",
                column: "Product_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_ProductId",
                table: "ProductType",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductType_Product_ProductId",
                table: "ProductType",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductType_Product_Type_Product_TypeId",
                table: "ProductType",
                column: "Product_TypeId",
                principalTable: "Product_Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
