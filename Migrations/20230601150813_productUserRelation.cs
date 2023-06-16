using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class productUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userAppsId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAppId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_userAppsId",
                table: "Products",
                column: "userAppsId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserAppId",
                table: "AspNetUsers",
                column: "UserAppId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_UserAppId",
                table: "AspNetUsers",
                column: "UserAppId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_userAppsId",
                table: "Products",
                column: "userAppsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_UserAppId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_userAppsId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_userAppsId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserAppId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "userAppsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserAppId",
                table: "AspNetUsers");
        }
    }
}
