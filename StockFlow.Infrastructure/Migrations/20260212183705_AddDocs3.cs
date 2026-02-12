using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDocs3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Balances_ResourceId_UnitId",
                table: "Balances",
                columns: new[] { "ResourceId", "UnitId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Balances_UnitId",
                table: "Balances",
                column: "UnitId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_Units_UnitId",
                table: "Balances",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_Units_UnitId",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_ResourceId_UnitId",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_UnitId",
                table: "Balances");
        }
    }
}
