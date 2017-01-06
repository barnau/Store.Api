using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Api.Migrations
{
    public partial class AddCustPropToAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customers_CustomerId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Addresses",
                newName: "customerId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                newName: "IX_Addresses_customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Customers_customerId",
                table: "Addresses",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customers_customerId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Addresses",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_customerId",
                table: "Addresses",
                newName: "IX_Addresses_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Customers_CustomerId",
                table: "Addresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
