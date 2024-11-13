using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BEBourbonCollective.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Distilleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distilleries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirebaseId = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bourbons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    DistilleryId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OpenBottle = table.Column<bool>(type: "boolean", nullable: false),
                    EmptyBottle = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bourbons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bourbons_Distilleries_DistilleryId",
                        column: x => x.DistilleryId,
                        principalTable: "Distilleries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bourbons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TradeRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestingUserId = table.Column<int>(type: "integer", nullable: false),
                    RequestingBourbonId = table.Column<int>(type: "integer", nullable: false),
                    RequestingFromBourbonId = table.Column<int>(type: "integer", nullable: false),
                    RequestedFromUserId = table.Column<int>(type: "integer", nullable: false),
                    RequestedFromBourbonId = table.Column<int>(type: "integer", nullable: false),
                    Pending = table.Column<bool>(type: "boolean", nullable: false),
                    Approved = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TradeRequests_Bourbons_RequestedFromBourbonId",
                        column: x => x.RequestedFromBourbonId,
                        principalTable: "Bourbons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeRequests_Bourbons_RequestingFromBourbonId",
                        column: x => x.RequestingFromBourbonId,
                        principalTable: "Bourbons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeRequests_Users_RequestedFromUserId",
                        column: x => x.RequestedFromUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeRequests_Users_RequestingUserId",
                        column: x => x.RequestingUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBourbons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    BourbonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBourbons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBourbons_Bourbons_BourbonId",
                        column: x => x.BourbonId,
                        principalTable: "Bourbons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBourbons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Distilleries",
                columns: new[] { "Id", "City", "Name", "State" },
                values: new object[,]
                {
                    { 1, "Frankfort", "Buffalo Trace", "Kentucky" },
                    { 2, "Versailles", "Woodford Reserve", "Kentucky" },
                    { 3, "Loretto", "Maker's Mark", "Kentucky" },
                    { 4, "Lawrenceburg", "Four Roses", "Kentucky" },
                    { 5, "Frankfort", "Whiskey Thief", "Kentucky" },
                    { 6, "Bardstown", "Willett", "Kentucky" },
                    { 7, "Frankfort", "Castle & Key", "Kentucky" },
                    { 8, "Louisville", "Evan Williams", "Kentucky" },
                    { 9, "Shively", "Stitzel-Weller", "Kentucky" },
                    { 10, "Lousiville", "Angel's Envy", "Kentucky" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "Email", "FirebaseId", "FullName", "State", "Username" },
                values: new object[] { 1, "Brandenburg", "felicia_mings@yahoo.com", "C0wunKp1sIQRM9YR48JnQPlNXt92", "Felicia Yahoo", "Kentucky", "bourbondrinker01" });

            migrationBuilder.InsertData(
                table: "Bourbons",
                columns: new[] { "Id", "DistilleryId", "EmptyBottle", "Name", "OpenBottle", "UserId" },
                values: new object[,]
                {
                    { 1, 1, false, "Buffalo Trace Kentucky Straight Bourbon Whiskey", true, 1 },
                    { 2, 2, false, "Straight Bourbon Whiskey", false, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserBourbons",
                columns: new[] { "Id", "BourbonId", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Bourbons_DistilleryId",
                table: "Bourbons",
                column: "DistilleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Bourbons_UserId",
                table: "Bourbons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeRequests_RequestedFromBourbonId",
                table: "TradeRequests",
                column: "RequestedFromBourbonId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeRequests_RequestedFromUserId",
                table: "TradeRequests",
                column: "RequestedFromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeRequests_RequestingFromBourbonId",
                table: "TradeRequests",
                column: "RequestingFromBourbonId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeRequests_RequestingUserId",
                table: "TradeRequests",
                column: "RequestingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBourbons_BourbonId",
                table: "UserBourbons",
                column: "BourbonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBourbons_UserId",
                table: "UserBourbons",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradeRequests");

            migrationBuilder.DropTable(
                name: "UserBourbons");

            migrationBuilder.DropTable(
                name: "Bourbons");

            migrationBuilder.DropTable(
                name: "Distilleries");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
