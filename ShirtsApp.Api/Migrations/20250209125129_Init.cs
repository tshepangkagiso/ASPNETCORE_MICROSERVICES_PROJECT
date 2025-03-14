using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShirtsApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shirts",
                columns: table => new
                {
                    ShirtID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shirts", x => x.ShirtID);
                });

            migrationBuilder.InsertData(
                table: "Shirts",
                columns: new[] { "ShirtID", "Brand", "Color", "Size" },
                values: new object[,]
                {
                    { 1, "Polo", "Black", 30 },
                    { 2, "Nike", "Gray", 50 },
                    { 3, "D&G", "Red", 28 },
                    { 4, "Puma", "Blue", 14 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shirts");
        }
    }
}
