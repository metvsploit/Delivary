using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Pizza_Name_IsUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Pizzas_Name",
                table: "Pizzas");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_Name",
                table: "Pizzas",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pizzas_Name",
                table: "Pizzas");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Pizzas_Name",
                table: "Pizzas",
                column: "Name");
        }
    }
}
