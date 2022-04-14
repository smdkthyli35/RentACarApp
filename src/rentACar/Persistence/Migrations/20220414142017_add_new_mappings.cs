using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class add_new_mappings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentedCityId",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "DeliveryCityId",
                table: "Rentals",
                newName: "CityId");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCity",
                table: "Rentals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RentedCity",
                table: "Rentals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CityId",
                table: "Rentals",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Cities_CityId",
                table: "Rentals",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Cities_CityId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_CityId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "DeliveryCity",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "RentedCity",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Rentals",
                newName: "DeliveryCityId");

            migrationBuilder.AddColumn<int>(
                name: "RentedCityId",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
