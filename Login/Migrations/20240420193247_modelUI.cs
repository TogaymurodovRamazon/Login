using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Login.Migrations
{
    /// <inheritdoc />
    public partial class modelUI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Discounts_DiscountId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ModifeiledDate",
                table: "Users",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifeiledDate",
                table: "Products",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifeiledDate",
                table: "Persons",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifeiledDate",
                table: "Employees",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifeiledDate",
                table: "Discounts",
                newName: "StarDate");

            migrationBuilder.RenameColumn(
                name: "ModifeiledDate",
                table: "Clients",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifeiledDate",
                table: "CheckPrintingDatas",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifeiledDate",
                table: "CashBoxes",
                newName: "ModifiedDate");

            migrationBuilder.AlterColumn<long>(
                name: "DiscountId",
                table: "Products",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                table: "Products",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountStatus",
                table: "Discounts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_IsDeleted",
                table: "Users",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsDeleted",
                table: "Products",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_IsDeleted",
                table: "Persons",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IsDeleted",
                table: "Employees",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_IsDeleted",
                table: "Discounts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IsDeleted",
                table: "Clients",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CheckPrintingDatas_IsDeleted",
                table: "CheckPrintingDatas",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CashBoxes_IsDeleted",
                table: "CashBoxes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_IsDeleted",
                table: "Companies",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_IsDeleted",
                table: "ProductCategories",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Discounts_DiscountId",
                table: "Products",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Discounts_DiscountId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_Users_IsDeleted",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CompanyId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IsDeleted",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Persons_IsDeleted",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Employees_IsDeleted",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_IsDeleted",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Clients_IsDeleted",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_CheckPrintingDatas_IsDeleted",
                table: "CheckPrintingDatas");

            migrationBuilder.DropIndex(
                name: "IX_CashBoxes_IsDeleted",
                table: "CashBoxes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiscountStatus",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Discounts");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Users",
                newName: "ModifeiledDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Products",
                newName: "ModifeiledDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Persons",
                newName: "ModifeiledDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Employees",
                newName: "ModifeiledDate");

            migrationBuilder.RenameColumn(
                name: "StarDate",
                table: "Discounts",
                newName: "ModifeiledDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Clients",
                newName: "ModifeiledDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "CheckPrintingDatas",
                newName: "ModifeiledDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "CashBoxes",
                newName: "ModifeiledDate");

            migrationBuilder.AlterColumn<long>(
                name: "DiscountId",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Discounts_DiscountId",
                table: "Products",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
