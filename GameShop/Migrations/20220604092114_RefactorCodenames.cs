using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameShop.Migrations
{
    /// <inheritdoc />
    public partial class RefactorCodenames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Type_ProductType_Product_TypeId",
                table: "Product_Type");

            migrationBuilder.RenameColumn(
                name: "Product_amount",
                table: "WarhouseItem",
                newName: "ProductAmount");

            migrationBuilder.RenameColumn(
                name: "URL",
                table: "Product",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Product_price",
                table: "Product",
                newName: "ProductPrice");

            migrationBuilder.RenameColumn(
                name: "Product_name",
                table: "Product",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "Product_image",
                table: "Product",
                newName: "ProductImage");

            migrationBuilder.RenameColumn(
                name: "Product_description",
                table: "Product",
                newName: "ProductDescription");

            migrationBuilder.RenameColumn(
                name: "Package_list",
                table: "Product",
                newName: "PackageList");

            migrationBuilder.RenameColumn(
                name: "Num_of_players",
                table: "Product",
                newName: "NumOfPlayers");

            migrationBuilder.RenameColumn(
                name: "Game_duration",
                table: "Product",
                newName: "GameDuration");

            migrationBuilder.AlterColumn<long>(
                name: "Product_TypeId",
                table: "Product_Type",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Type_ProductType_Product_TypeId",
                table: "Product_Type",
                column: "Product_TypeId",
                principalTable: "ProductType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Type_ProductType_Product_TypeId",
                table: "Product_Type");

            migrationBuilder.RenameColumn(
                name: "ProductAmount",
                table: "WarhouseItem",
                newName: "Product_amount");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Product",
                newName: "URL");

            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "Product",
                newName: "Product_price");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Product",
                newName: "Product_name");

            migrationBuilder.RenameColumn(
                name: "ProductImage",
                table: "Product",
                newName: "Product_image");

            migrationBuilder.RenameColumn(
                name: "ProductDescription",
                table: "Product",
                newName: "Product_description");

            migrationBuilder.RenameColumn(
                name: "PackageList",
                table: "Product",
                newName: "Package_list");

            migrationBuilder.RenameColumn(
                name: "NumOfPlayers",
                table: "Product",
                newName: "Num_of_players");

            migrationBuilder.RenameColumn(
                name: "GameDuration",
                table: "Product",
                newName: "Game_duration");

            migrationBuilder.AlterColumn<long>(
                name: "Product_TypeId",
                table: "Product_Type",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Type_ProductType_Product_TypeId",
                table: "Product_Type",
                column: "Product_TypeId",
                principalTable: "ProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
