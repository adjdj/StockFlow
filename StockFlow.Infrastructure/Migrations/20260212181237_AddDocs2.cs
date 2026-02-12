using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDocs2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptItem_ReceiptDocuments_ReceiptDocumentId",
                table: "ReceiptItem");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptDocuments_Number",
                table: "ReceiptDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptItem",
                table: "ReceiptItem");

            migrationBuilder.RenameTable(
                name: "ReceiptItem",
                newName: "ReceiptItems");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptItem_ReceiptDocumentId",
                table: "ReceiptItems",
                newName: "IX_ReceiptItems_ReceiptDocumentId");

            migrationBuilder.AddColumn<Guid>(
                name: "UnitId",
                table: "Balances",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptItems",
                table: "ReceiptItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptItems_ReceiptDocuments_ReceiptDocumentId",
                table: "ReceiptItems",
                column: "ReceiptDocumentId",
                principalTable: "ReceiptDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptItems_ReceiptDocuments_ReceiptDocumentId",
                table: "ReceiptItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptItems",
                table: "ReceiptItems");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Balances");

            migrationBuilder.RenameTable(
                name: "ReceiptItems",
                newName: "ReceiptItem");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptItems_ReceiptDocumentId",
                table: "ReceiptItem",
                newName: "IX_ReceiptItem_ReceiptDocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptItem",
                table: "ReceiptItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDocuments_Number",
                table: "ReceiptDocuments",
                column: "Number",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptItem_ReceiptDocuments_ReceiptDocumentId",
                table: "ReceiptItem",
                column: "ReceiptDocumentId",
                principalTable: "ReceiptDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
