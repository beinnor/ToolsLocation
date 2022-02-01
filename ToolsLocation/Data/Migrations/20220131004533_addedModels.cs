using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolsLocation.Data.Migrations
{
    public partial class addedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelfName = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    ShelfFloor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    ToolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.ToolId);
                    table.ForeignKey(
                        name: "FK_Tools_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "ShelfFloor", "ShelfName" },
                values: new object[] { 1, 0, "A" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "ShelfFloor", "ShelfName" },
                values: new object[] { 2, 3, "B" });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "ToolId", "Brand", "LocationId", "Model", "Name" },
                values: new object[] { 1, "Hitachi", 1, "DS 18DJL", "Hitachi Drill" });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "ToolId", "Brand", "LocationId", "Model", "Name" },
                values: new object[] { 2, "Bosch", 2, "unknown", "Circular Saw" });

            migrationBuilder.CreateIndex(
                name: "IX_Tools_LocationId",
                table: "Tools",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
