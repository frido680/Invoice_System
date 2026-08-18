using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice_System.Migrations
{
    /// <inheritdoc />
    public partial class NameFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitPriceAtOder",
                table: "OrderItems",
                newName: "UnitPriceAtOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitPriceAtOrder",
                table: "OrderItems",
                newName: "UnitPriceAtOder");
        }
    }
}
