using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BEBourbonCollective.Migrations
{
    /// <inheritdoc />
    public partial class tradeRequestFKFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TradeRequests_Bourbons_RequestedFromBourbonId",
                table: "TradeRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TradeRequests_Bourbons_RequestingFromBourbonId",
                table: "TradeRequests");

            migrationBuilder.DropIndex(
                name: "IX_TradeRequests_RequestingFromBourbonId",
                table: "TradeRequests");

            migrationBuilder.DropColumn(
                name: "RequestingFromBourbonId",
                table: "TradeRequests");

            migrationBuilder.CreateIndex(
                name: "IX_TradeRequests_RequestingBourbonId",
                table: "TradeRequests",
                column: "RequestingBourbonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TradeRequests_Bourbons_RequestedFromBourbonId",
                table: "TradeRequests",
                column: "RequestedFromBourbonId",
                principalTable: "Bourbons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TradeRequests_Bourbons_RequestingBourbonId",
                table: "TradeRequests",
                column: "RequestingBourbonId",
                principalTable: "Bourbons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TradeRequests_Bourbons_RequestedFromBourbonId",
                table: "TradeRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TradeRequests_Bourbons_RequestingBourbonId",
                table: "TradeRequests");

            migrationBuilder.DropIndex(
                name: "IX_TradeRequests_RequestingBourbonId",
                table: "TradeRequests");

            migrationBuilder.AddColumn<int>(
                name: "RequestingFromBourbonId",
                table: "TradeRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TradeRequests_RequestingFromBourbonId",
                table: "TradeRequests",
                column: "RequestingFromBourbonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TradeRequests_Bourbons_RequestedFromBourbonId",
                table: "TradeRequests",
                column: "RequestedFromBourbonId",
                principalTable: "Bourbons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TradeRequests_Bourbons_RequestingFromBourbonId",
                table: "TradeRequests",
                column: "RequestingFromBourbonId",
                principalTable: "Bourbons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
