using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Country_City_CityId",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Country_CityId",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Country");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Service",
                type: "decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Service",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,17)");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Country",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_CityId",
                table: "Country",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Country_City_CityId",
                table: "Country",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");
        }
    }
}
