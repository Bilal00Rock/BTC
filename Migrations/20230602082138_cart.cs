using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "Cats");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_UserAppId",
                table: "Cats",
                newName: "IX_Cats_UserAppId");

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
                table: "Cats",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cats",
                table: "Cats",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cats_AspNetUsers_UserAppId",
                table: "Cats",
                column: "UserAppId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Cats_Cartid",
                table: "Products",
                column: "Cartid",
                principalTable: "Cats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cats_AspNetUsers_UserAppId",
                table: "Cats");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cats_Cartid",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cats",
                table: "Cats");

            migrationBuilder.RenameTable(
                name: "Cats",
                newName: "Cart");

            migrationBuilder.RenameIndex(
                name: "IX_Cats_UserAppId",
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
    }
}
