using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class initstart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FOOD_TABLE");

            migrationBuilder.DropTable(
                name: "userRoles");

            migrationBuilder.DropTable(
                name: "V_FoodsOnTable");

            migrationBuilder.DropTable(
                name: "V_TableInCanva");

            migrationBuilder.DropTable(
                name: "CafeteriaTable");

            migrationBuilder.DropTable(
                name: "FoodType");

            migrationBuilder.DropTable(
                name: "CANVA_ADMIN");

            migrationBuilder.DropTable(
                name: "ShapeType");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Canva");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID_ADMIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PASSWORDHASH = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SALT = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UPDATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID_ADMIN);
                });

            migrationBuilder.CreateTable(
                name: "Canva",
                columns: table => new
                {
                    ID_CANVA = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HEIGHT = table.Column<double>(type: "float", nullable: true),
                    UPDATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WIDTH = table.Column<double>(type: "float", nullable: true)
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
                    AMOUNT_LEFT = table.Column<int>(type: "int", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FOOD_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FOOD_TYPENAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FOOD_TYPE_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMAGE_LINK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UPDATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodType", x => x.ID_FOOD);
                });

            migrationBuilder.CreateTable(
                name: "ShapeType",
                columns: table => new
                {
                    ID_SHAPE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HEIGHT = table.Column<double>(type: "float", nullable: true),
                    RADIUS = table.Column<double>(type: "float", nullable: true),
                    SHAPE_TYPENAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UPDATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WIDTH = table.Column<double>(type: "float", nullable: true)
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
                    AMOUNT_IN_TABLE = table.Column<int>(type: "int", nullable: true),
                    AMOUNT_LEFT = table.Column<int>(type: "int", nullable: true),
                    FOOD_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FOOD_TYPE_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMAGE_LINK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
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
                    HEIGHT = table.Column<double>(type: "float", nullable: true),
                    ID_CANVA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_SHAPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RADIUS = table.Column<double>(type: "float", nullable: true),
                    TABLE_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WIDTH = table.Column<double>(type: "float", nullable: true),
                    X_COORDINATE = table.Column<double>(type: "float", nullable: true),
                    Y_COORDINATE = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_TableInCanva", x => x.ID_TABLE);
                });

            migrationBuilder.CreateTable(
                name: "CANVA_ADMIN",
                columns: table => new
                {
                    ID_CANVA = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ID_ADMIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LOGIN_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "CafeteriaTable",
                columns: table => new
                {
                    ID_TABLE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CANVA_ADMINID_CANVA = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SHAPE_TYPEID_SHAPE = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CANVA_ADMINID_ADMIN = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ID_ADMIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_CANVA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_SHAPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TABLE_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UPDATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    X_COORDINATE = table.Column<double>(type: "float", nullable: true),
                    Y_COORDINATE = table.Column<double>(type: "float", nullable: true)
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
        }
    }
}
