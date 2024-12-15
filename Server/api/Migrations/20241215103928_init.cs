using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "AspNetAPI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    API = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetAPI", x => x.Id);
                });
            migrationBuilder.AddColumn<string>(
                name: "STATUS",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
        name: "ApiId",
        table: "AspNetRoleMenu",
        type: "int",
        nullable: true); // Set nullable to true if the column doesn't require an immediate value

            // Add a foreign key constraint if IdApi references another table
            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleMenu_AspNetAPI_ApiId",
                table: "AspNetRoleMenu",
                column: "ApiId",
                principalTable: "AspNetAPI",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);



            

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleMenu_ApiId",
                table: "AspNetRoleMenu",
                column: "ApiId");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the foreign key constraint if added
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleMenu_AspNetAPI_IdApi",
                table: "AspNetRoleMenu");

            // Remove the column
            migrationBuilder.DropColumn(
                name: "IdApi",
                table: "AspNetRoleMenu");
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FOOD_TABLE");

            migrationBuilder.DropTable(
                name: "MenuPermission");

            migrationBuilder.DropTable(
                name: "userRoles");

            migrationBuilder.DropTable(
                name: "V_FoodsOnTable");

            migrationBuilder.DropTable(
                name: "V_TableInCanva");

            migrationBuilder.DropTable(
                name: "VMenus");

            migrationBuilder.DropTable(
                name: "VPermission_Roles");

            migrationBuilder.DropTable(
                name: "VRole_Menus");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CafeteriaTable");

            migrationBuilder.DropTable(
                name: "FoodType");

            migrationBuilder.DropTable(
                name: "AspNetRoleMenu");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "CANVA_ADMIN");

            migrationBuilder.DropTable(
                name: "ShapeType");

            migrationBuilder.DropTable(
                name: "AspNetAPI");

            migrationBuilder.DropTable(
                name: "AspNetMenu");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Canva");
        }
    }
}
