using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreenThumb.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Instructions_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Thorny, comes in a lot of colours. A universal symbol of love and admiration", "Rose" },
                    { 2, "Golden, star-shaped flower that grows in abundance in the forest of Lórien.", "Elanor" },
                    { 3, "Thorny useless plant, doesn't need a lot of water and requires little to no tending. Perfect gift for children you don't like.", "Cactus" }
                });

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "id", "Instruction", "PlantId" },
                values: new object[,]
                {
                    { 1, "Six to eight hours of sun per day required.", 1 },
                    { 2, "Plant in well drained soil rich with organic matter", 1 },
                    { 3, "Keep away from orcs", 2 },
                    { 4, "Water cautiously as to not drain the soil", 3 },
                    { 5, "Keep away from children", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_PlantId",
                table: "Instructions",
                column: "PlantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
