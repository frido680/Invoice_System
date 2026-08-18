using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice_System.Migrations
{
    /// <inheritdoc />
    public partial class IsDiscountEligibleFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDiscountEligible",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDiscountEligible",
                table: "Products");
        }
    }
}