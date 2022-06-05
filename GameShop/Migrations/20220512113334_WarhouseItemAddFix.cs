using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameShop.Migrations
{
    public partial class WarhouseItemAddFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WarhouseItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Product_amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarhouseItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarhouseItem_Product_Id",
                        column: x => x.Id,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarhouseItem");
        }
    }
}
