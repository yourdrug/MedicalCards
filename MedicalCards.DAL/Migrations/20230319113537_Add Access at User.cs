using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCards.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddAccessatUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Access",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Access",
                table: "Users");
        }
    }
}
