using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHousingApi.DataModel.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries_tbl",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries_tbl", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers_tbl",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierTell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers_tbl", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Products_tbl",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackingType = table.Column<int>(type: "int", nullable: true),
                    CountInPacking = table.Column<int>(type: "int", nullable: false),
                    ProductWeight = table.Column<int>(type: "int", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRefregerator = table.Column<byte>(type: "tinyint", nullable: false),
                    SuplierId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_tbl", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_tbl_Countries_tbl_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries_tbl",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_tbl_Suppliers_tbl_SuplierId",
                        column: x => x.SuplierId,
                        principalTable: "Suppliers_tbl",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_tbl_CountryId",
                table: "Products_tbl",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_tbl_SuplierId",
                table: "Products_tbl",
                column: "SuplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products_tbl");

            migrationBuilder.DropTable(
                name: "Countries_tbl");

            migrationBuilder.DropTable(
                name: "Suppliers_tbl");
        }
    }
}
