using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMobile.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MobileDBContexts",
                columns: table => new
                {
                    MobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MobName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileDBContexts", x => x.MobId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobileDBContexts");
        }
    }
}
