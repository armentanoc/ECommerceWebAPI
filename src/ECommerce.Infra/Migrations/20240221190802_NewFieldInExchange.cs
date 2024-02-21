using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Infra.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldInExchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PriceDifference",
                table: "Exchange",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceDifference",
                table: "Exchange");
        }
    }
}
