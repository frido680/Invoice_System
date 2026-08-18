using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice_System.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderItemUnitPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "UnitPriceAtOder",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPriceAtOder",
                table: "OrderItems");
        }
    }
}
