using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaCommerce.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Exclude_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductValue",
                table: "Shopping");

            migrationBuilder.DropColumn(
                name: "ProductVolumn",
                table: "Shopping");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ProductValue",
                table: "Shopping",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductVolumn",
                table: "Shopping",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
