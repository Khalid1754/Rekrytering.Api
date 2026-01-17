using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rekrytering.Api.Migrations
{
    /// <inheritdoc />
    public partial class SkapaSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kandidater",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Namn = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Kompetens = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kandidater", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Kandidater",
                columns: new[] { "Id", "Email", "Kompetens", "Namn", "Status" },
                values: new object[,]
                {
                    { 1, "Khalid.Hassan@example.com", "Backend", "Khalid Hassan", 0 },
                    { 2, "Gandalf.Grey@example.com", "Frontend", "´Gandalf Grey", 1 },
                    { 3, "Drake.OVO@example.com", "Fullstack", "Drake OVO", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kandidater");
        }
    }
}
