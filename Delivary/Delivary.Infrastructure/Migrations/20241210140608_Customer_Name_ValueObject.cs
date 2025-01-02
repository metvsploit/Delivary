using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Customer_Name_ValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customers",
                newName: "Name_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "Name_FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name_LastName",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name_FirstName",
                table: "Customers",
                newName: "FirstName");
        }
    }
}
