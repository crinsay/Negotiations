using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Negotiations.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameIsAcceptedToStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Negotiations");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Negotiations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Pending");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Negotiations");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Negotiations",
                type: "bit",
                nullable: true);
        }
    }
}
