using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWatch.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WatchDBContexts",
                columns: table => new
                {
                    WatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WatchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WatchModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WatchPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WatchColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchDBContexts", x => x.WatchId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WatchDBContexts");
        }
    }
}
