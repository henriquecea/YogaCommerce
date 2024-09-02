using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaCommerce.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Add_Column_TermsOfUseAccepted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TermsOfUseAccepted",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TermsOfUseAccepted",
                table: "User");
        }
    }
}
