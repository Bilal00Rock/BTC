using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class newest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserAppId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Carts_Cartid",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "Cart");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_UserAppId",
                table: "Cart",
                newName: "IX_Cart_UserAppId");

            migrationBuilder.AlterColumn<string>(
                name: "Cartid",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserAppId",
                table: "Cart",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_AspNetUsers_UserAppId",
                table: "Cart",
                column: "UserAppId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Cart_Cartid",
                table: "Products",
                column: "Cartid",
                principalTable: "Cart",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_AspNetUsers_UserAppId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cart_Cartid",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "Carts");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_UserAppId",
                table: "Carts",
                newName: "IX_Carts_UserAppId");

            migrationBuilder.AlterColumn<string>(
                name: "Cartid",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserAppId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_UserAppId",
                table: "Carts",
                column: "UserAppId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Carts_Cartid",
                table: "Products",
                column: "Cartid",
                principalTable: "Carts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
