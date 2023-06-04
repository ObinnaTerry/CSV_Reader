using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSV_Reader.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemName = table.Column<string>(type: "TEXT", nullable: true),
                    Manufacturer = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    MaterialInformation = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    ProductType = table.Column<string>(type: "TEXT", nullable: true),
                    Sleeve = table.Column<string>(type: "TEXT", nullable: true),
                    Leg = table.Column<string>(type: "TEXT", nullable: true),
                    Collar = table.Column<string>(type: "TEXT", nullable: true),
                    Manufacture = table.Column<string>(type: "TEXT", nullable: true),
                    BagType = table.Column<string>(type: "TEXT", nullable: true),
                    GramWeight = table.Column<double>(type: "REAL", nullable: false),
                    Material = table.Column<string>(type: "TEXT", nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "TEXT", nullable: true),
                    ImageName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
