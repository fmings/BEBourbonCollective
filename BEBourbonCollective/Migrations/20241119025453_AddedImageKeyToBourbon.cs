using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BEBourbonCollective.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageKeyToBourbon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Bourbons",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Bourbons",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://curiada.com/cdn/shop/products/BuffaloTrace1LTransp_1024x1024.png?v=1669377439");

            migrationBuilder.UpdateData(
                table: "Bourbons",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://whiskyandwhiskey.com/cdn/shop/products/Bourbon-Bottle.png?v=1654035434");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Bourbons");
        }
    }
}
