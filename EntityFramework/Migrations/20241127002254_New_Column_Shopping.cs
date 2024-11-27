using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaCommerce.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class New_Column_Shopping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ProductVolumn",
                table: "Shopping",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductVolumn",
                table: "Shopping");
        }
    }
}
