using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Storemicroservice.Data.Migrations
{
    /// <inheritdoc />
    public partial class CartCartitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            //migrationBuilder.CreateTable(
            //    name: "Cart",
            //    columns: table => new
            //    {
            //        CartId = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        UserId = table.Column<string>(type: "text", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Cart", x => x.CartId);
            //        table.ForeignKey(
            //            name: "FK_Cart_ApplicationUser_UserId",
            //            column: x => x.UserId,
            //            principalTable: "ApplicationUser",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });


            
            //migrationBuilder.CreateTable(
            //    name: "CartItems",
            //    columns: table => new
            //    {
            //        CartItemId = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        CartId = table.Column<int>(type: "integer", nullable: false),
            //        ProductId = table.Column<int>(type: "integer", nullable: false),
            //        Quantity = table.Column<int>(type: "integer", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CartItems", x => x.CartItemId);
            //        table.ForeignKey(
            //            name: "FK_CartItems_Cart_CartId",
            //            column: x => x.CartId,
            //            principalTable: "Cart",
            //            principalColumn: "CartId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CartItems_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "ProductId",
            //            onDelete: ReferentialAction.Cascade);
            //    });


           

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cart_UserId",
            //    table: "Cart",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CartItems_CartId",
            //    table: "CartItems",
            //    column: "CartId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CartItems_ProductId",
            //    table: "CartItems",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Images_ProductId",
            //    table: "Images",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ItemSizes_SizeId",
            //    table: "ItemSizes",
            //    column: "SizeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_FK_GenderId",
            //    table: "Products",
            //    column: "FK_GenderId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_FK_SubcategoryId",
            //    table: "Products",
            //    column: "FK_SubcategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_GenderId",
            //    table: "Products",
            //    column: "GenderId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Subcategories_FK_CategoryId",
            //    table: "Subcategories",
            //    column: "FK_CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "ItemSizes");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
