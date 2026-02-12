using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDocs4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_Resources_ResourceId",
                table: "Balances");

            migrationBuilder.DropForeignKey(
                name: "FK_Balances_Units_UnitId",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_ResourceId",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_UnitId",
                table: "Balances");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_UnitId",
                table: "Balances",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_Resources_ResourceId",
                table: "Balances",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_Units_UnitId",
                table: "Balances",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_Resources_ResourceId",
                table: "Balances");

            migrationBuilder.DropForeignKey(
                name: "FK_Balances_Units_UnitId",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_UnitId",
                table: "Balances");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_ResourceId",
                table: "Balances",
                column: "ResourceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Balances_UnitId",
                table: "Balances",
                column: "UnitId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_Resources_ResourceId",
                table: "Balances",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_Units_UnitId",
                table: "Balances",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
