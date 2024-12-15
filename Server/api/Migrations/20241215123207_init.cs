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

            migrationBuilder.CreateTable(
                name: "AspNetMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetMenu_AspNetMenu_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AspNetMenu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Canva",
                columns: table => new
                {
                    ID_CANVA = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WIDTH = table.Column<double>(type: "float", nullable: true),
                    HEIGHT = table.Column<double>(type: "float", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canva", x => x.ID_CANVA);
                });

            migrationBuilder.CreateTable(
                name: "FoodType",
                columns: table => new
                {
                    ID_FOOD = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FOOD_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FOOD_TYPENAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AMOUNT_LEFT = table.Column<int>(type: "int", nullable: true),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FOOD_TYPE_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMAGE_LINK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodType", x => x.ID_FOOD);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShapeType",
                columns: table => new
                {
                    ID_SHAPE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WIDTH = table.Column<double>(type: "float", nullable: true),
                    HEIGHT = table.Column<double>(type: "float", nullable: true),
                    RADIUS = table.Column<double>(type: "float", nullable: true),
                    SHAPE_TYPENAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShapeType", x => x.ID_SHAPE);
                });

            migrationBuilder.CreateTable(
                name: "userRoles",
                columns: table => new
                {
                    ROLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "V_FoodsOnTable",
                columns: table => new
                {
                    ID_FOOD = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ID_TABLE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FOOD_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AMOUNT_LEFT = table.Column<int>(type: "int", nullable: true),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FOOD_TYPE_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMAGE_LINK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AMOUNT_IN_TABLE = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_FoodsOnTable", x => new { x.ID_FOOD, x.ID_TABLE });
                });

            migrationBuilder.CreateTable(
                name: "V_TableInCanva",
                columns: table => new
                {
                    ID_TABLE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    X_COORDINATE = table.Column<double>(type: "float", nullable: true),
                    Y_COORDINATE = table.Column<double>(type: "float", nullable: true),
                    WIDTH = table.Column<double>(type: "float", nullable: true),
                    HEIGHT = table.Column<double>(type: "float", nullable: true),
                    RADIUS = table.Column<double>(type: "float", nullable: true),
                    TABLE_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_SHAPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_CANVA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_TableInCanva", x => x.ID_TABLE);
                });

            migrationBuilder.CreateTable(
                name: "VMenus",
                columns: table => new
                {
                    menuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    menuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    menuParent = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VMenus", x => x.menuID);
                });

            migrationBuilder.CreateTable(
                name: "VPermission_Roles",
                columns: table => new
                {
                    rolemenuID = table.Column<int>(type: "int", nullable: false),
                    permissionID = table.Column<int>(type: "int", nullable: false),
                    permissionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VPermission_Roles", x => new { x.rolemenuID, x.permissionID });
                });

            migrationBuilder.CreateTable(
                name: "VRole_Menus",
                columns: table => new
                {
                    menuID = table.Column<int>(type: "int", nullable: false),
                    rolemenuID = table.Column<int>(type: "int", nullable: false),
                    permissionID = table.Column<int>(type: "int", nullable: false),
                    roleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VRole_Menus", x => new { x.menuID, x.rolemenuID, x.permissionID });
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleAPI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleAPI", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleAPI_AspNetAPI_ApiId",
                        column: x => x.ApiId,
                        principalTable: "AspNetAPI",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetRoleAPI_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleMenu_AspNetMenu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "AspNetMenu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetRoleMenu_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CANVA_ADMIN",
                columns: table => new
                {
                    ID_CANVA = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ID_ADMIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LOGIN_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CANVA_ADMIN", x => new { x.ID_CANVA, x.ID_ADMIN });
                    table.ForeignKey(
                        name: "FK_CANVA_ADMIN_Admin_ID_ADMIN",
                        column: x => x.ID_ADMIN,
                        principalTable: "Admin",
                        principalColumn: "ID_ADMIN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CANVA_ADMIN_Canva_ID_CANVA",
                        column: x => x.ID_CANVA,
                        principalTable: "Canva",
                        principalColumn: "ID_CANVA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiPermission",
                columns: table => new
                {
                    RoleApiId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiPermission", x => new { x.RoleApiId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_ApiPermission_AspNetRoleAPI_RoleApiId",
                        column: x => x.RoleApiId,
                        principalTable: "AspNetRoleAPI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApiPermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuPermission",
                columns: table => new
                {
                    RoleMenuId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPermission", x => new { x.RoleMenuId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_MenuPermission_AspNetRoleMenu_RoleMenuId",
                        column: x => x.RoleMenuId,
                        principalTable: "AspNetRoleMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuPermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CafeteriaTable",
                columns: table => new
                {
                    ID_TABLE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    X_COORDINATE = table.Column<double>(type: "float", nullable: true),
                    Y_COORDINATE = table.Column<double>(type: "float", nullable: true),
                    ID_SHAPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_CANVA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_ADMIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TABLE_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SHAPE_TYPEID_SHAPE = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CANVA_ADMINID_CANVA = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CANVA_ADMINID_ADMIN = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CafeteriaTable", x => x.ID_TABLE);
                    table.ForeignKey(
                        name: "FK_CafeteriaTable_CANVA_ADMIN_CANVA_ADMINID_CANVA_CANVA_ADMINID_ADMIN",
                        columns: x => new { x.CANVA_ADMINID_CANVA, x.CANVA_ADMINID_ADMIN },
                        principalTable: "CANVA_ADMIN",
                        principalColumns: new[] { "ID_CANVA", "ID_ADMIN" });
                    table.ForeignKey(
                        name: "FK_CafeteriaTable_ShapeType_SHAPE_TYPEID_SHAPE",
                        column: x => x.SHAPE_TYPEID_SHAPE,
                        principalTable: "ShapeType",
                        principalColumn: "ID_SHAPE");
                });

            migrationBuilder.CreateTable(
                name: "FOOD_TABLE",
                columns: table => new
                {
                    ID_FOOD = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ID_TABLE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AMOUNT_IN_TABLE = table.Column<int>(type: "int", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FOOD_TABLE", x => new { x.ID_FOOD, x.ID_TABLE });
                    table.ForeignKey(
                        name: "FK_FOOD_TABLE_CafeteriaTable_ID_TABLE",
                        column: x => x.ID_TABLE,
                        principalTable: "CafeteriaTable",
                        principalColumn: "ID_TABLE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FOOD_TABLE_FoodType_ID_FOOD",
                        column: x => x.ID_FOOD,
                        principalTable: "FoodType",
                        principalColumn: "ID_FOOD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiPermission_PermissionId",
                table: "ApiPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetMenu_ParentId",
                table: "AspNetMenu",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleAPI_ApiId",
                table: "AspNetRoleAPI",
                column: "ApiId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleAPI_RoleId",
                table: "AspNetRoleAPI",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleMenu_MenuId",
                table: "AspNetRoleMenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleMenu_RoleId",
                table: "AspNetRoleMenu",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CafeteriaTable_CANVA_ADMINID_CANVA_CANVA_ADMINID_ADMIN",
                table: "CafeteriaTable",
                columns: new[] { "CANVA_ADMINID_CANVA", "CANVA_ADMINID_ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_CafeteriaTable_SHAPE_TYPEID_SHAPE",
                table: "CafeteriaTable",
                column: "SHAPE_TYPEID_SHAPE");

            migrationBuilder.CreateIndex(
                name: "IX_CANVA_ADMIN_ID_ADMIN",
                table: "CANVA_ADMIN",
                column: "ID_ADMIN");

            migrationBuilder.CreateIndex(
                name: "IX_FOOD_TABLE_ID_TABLE",
                table: "FOOD_TABLE",
                column: "ID_TABLE");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermission_PermissionId",
                table: "MenuPermission",
                column: "PermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiPermission");

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
                name: "AspNetRoleAPI");

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
                name: "AspNetAPI");

            migrationBuilder.DropTable(
                name: "CANVA_ADMIN");

            migrationBuilder.DropTable(
                name: "ShapeType");

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
