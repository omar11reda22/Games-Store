using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Games.Migrations
{
    /// <inheritdoc />
    public partial class step1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discreption = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Cover = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_games_categories_categoryID",
                        column: x => x.categoryID,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gameDevices",
                columns: table => new
                {
                    gameid = table.Column<int>(type: "int", nullable: false),
                    deviceid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gameDevices", x => new { x.gameid, x.deviceid });
                    table.ForeignKey(
                        name: "FK_gameDevices_devices_deviceid",
                        column: x => x.deviceid,
                        principalTable: "devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gameDevices_games_gameid",
                        column: x => x.gameid,
                        principalTable: "games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "action" },
                    { 2, "Sports" },
                    { 3, "Racing" },
                    { 4, "adventure" },
                    { 5, "fighting" },
                    { 6, "Films" }
                });

            migrationBuilder.InsertData(
                table: "devices",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "bi bi-playstation", "playstation" },
                    { 4, "bi bi-pc-display-horizontal", "PC" },
                    { 5, "bi bi-nintendo-switch", "Nintendo switch" },
                    { 6, "bi bi-xbox", "XBOX" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_gameDevices_deviceid",
                table: "gameDevices",
                column: "deviceid");

            migrationBuilder.CreateIndex(
                name: "IX_games_categoryID",
                table: "games",
                column: "categoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gameDevices");

            migrationBuilder.DropTable(
                name: "devices");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
