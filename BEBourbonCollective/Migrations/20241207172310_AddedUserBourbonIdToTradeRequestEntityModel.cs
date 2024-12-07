using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BEBourbonCollective.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserBourbonIdToTradeRequestEntityModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserBourbonId",
                table: "TradeRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserBourbonId",
                table: "TradeRequests");
        }
    }
}
