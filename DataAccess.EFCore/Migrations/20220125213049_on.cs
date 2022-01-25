using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.EFCore.Migrations
{
    public partial class on : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientRestaurant_Clients_IdClient",
                table: "ClientRestaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientRestaurant_Restaurants_IdRestaurant",
                table: "ClientRestaurant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientRestaurant",
                table: "ClientRestaurant");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Waiters");

            migrationBuilder.RenameTable(
                name: "ClientRestaurant",
                newName: "ClientRestaurants");

            migrationBuilder.RenameIndex(
                name: "IX_ClientRestaurant_IdRestaurant",
                table: "ClientRestaurants",
                newName: "IX_ClientRestaurants_IdRestaurant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientRestaurants",
                table: "ClientRestaurants",
                columns: new[] { "IdClient", "IdRestaurant" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRestaurants_Clients_IdClient",
                table: "ClientRestaurants",
                column: "IdClient",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRestaurants_Restaurants_IdRestaurant",
                table: "ClientRestaurants",
                column: "IdRestaurant",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientRestaurants_Clients_IdClient",
                table: "ClientRestaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientRestaurants_Restaurants_IdRestaurant",
                table: "ClientRestaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientRestaurants",
                table: "ClientRestaurants");

            migrationBuilder.RenameTable(
                name: "ClientRestaurants",
                newName: "ClientRestaurant");

            migrationBuilder.RenameIndex(
                name: "IX_ClientRestaurants_IdRestaurant",
                table: "ClientRestaurant",
                newName: "IX_ClientRestaurant_IdRestaurant");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Waiters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientRestaurant",
                table: "ClientRestaurant",
                columns: new[] { "IdClient", "IdRestaurant" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRestaurant_Clients_IdClient",
                table: "ClientRestaurant",
                column: "IdClient",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRestaurant_Restaurants_IdRestaurant",
                table: "ClientRestaurant",
                column: "IdRestaurant",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
