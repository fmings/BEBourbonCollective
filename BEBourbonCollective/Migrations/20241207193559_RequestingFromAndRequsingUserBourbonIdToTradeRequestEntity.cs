using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BEBourbonCollective.Migrations
{
    /// <inheritdoc />
    public partial class RequestingFromAndRequsingUserBourbonIdToTradeRequestEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserBourbonId",
                table: "TradeRequests",
                newName: "RequestingUserBourbonId");

            migrationBuilder.AddColumn<int>(
                name: "RequestedFromUserBourbonId",
                table: "TradeRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestedFromUserBourbonId",
                table: "TradeRequests");

            migrationBuilder.RenameColumn(
                name: "RequestingUserBourbonId",
                table: "TradeRequests",
                newName: "UserBourbonId");
        }
    }
}
