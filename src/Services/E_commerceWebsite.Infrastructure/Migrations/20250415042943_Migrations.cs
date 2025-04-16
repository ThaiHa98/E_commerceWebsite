using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerceWebsite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Date_Create = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Update = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(28,10)", nullable: false),
                    Unit_price = table.Column<decimal>(type: "decimal(28,10)", nullable: false),
                    Total_price = table.Column<decimal>(type: "decimal(28,10)", nullable: false),
                    Image_url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Voucher_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gift_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date_Create = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_Update = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Product_Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date_Create = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "Gift",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Product_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountValue = table.Column<decimal>(type: "decimal(28,10)", nullable: false),
                    ProductGiftCondition = table.Column<int>(type: "int", nullable: false),
                    Image_url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Start_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    End_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gift", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Warehouse_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", maxLength: 250, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(28,10)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Image_url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Date_Create = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Update = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Total_amount = table.Column<decimal>(type: "decimal(28,10)", nullable: false),
                    Full_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Order_status = table.Column<int>(type: "int", nullable: false),
                    Payment_Status = table.Column<int>(type: "int", nullable: false),
                    Payment_Method = table.Column<int>(type: "int", nullable: false),
                    Date_Create = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Update = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "Order_Detail",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Unit_price = table.Column<decimal>(type: "decimal(28,10)", nullable: false),
                    Total_price = table.Column<decimal>(type: "decimal(28,10)", nullable: false),
                    Image_url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Detail", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Category_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Colors = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Image_url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date_Create = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Update = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "Product_Detail",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(28,10)", nullable: true),
                    Product_Warehouse_quantity = table.Column<decimal>(type: "decimal(28,10)", nullable: false),
                    Product_Warehouse_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image_url = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Date_Create = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Update = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Detail", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "Product_Price_Discount",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(28,10)", nullable: false),
                    Discount_percentage = table.Column<decimal>(type: "decimal(28,10)", nullable: true),
                    Discount_amount = table.Column<decimal>(type: "decimal(28,10)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Start_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    End_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Create = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Update = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Price_Discount", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "Product_Warehouse",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Warehouse_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(28,10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Warehouse", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role_Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false),
                    Role_Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Permission_Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false),
                    FunctionCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CommandCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Last_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    First_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Date_of_birth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Date_Create = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false),
                    User_Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Role_Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false),
                    Role_Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Discount_type = table.Column<int>(type: "int", nullable: false),
                    Discount_value = table.Column<decimal>(type: "decimal(28,10)", nullable: false),
                    Min_purchase_amount = table.Column<decimal>(type: "decimal(28,10)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Start_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    End_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date_Create = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Update = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.GuidId);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseInvoiceDetail",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Invoice_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Warehouse_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(28,10)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(28,10)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(28,10)", nullable: false),
                    Date_Create = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Update = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseInvoiceDetail", x => x.GuidId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Gift");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Order_Detail");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Product_Detail");

            migrationBuilder.DropTable(
                name: "Product_Price_Discount");

            migrationBuilder.DropTable(
                name: "Product_Warehouse");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "WarehouseInvoiceDetail");
        }
    }
}
