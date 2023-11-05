using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using RestaurantManagementSystem.src.Core.RestaurantManagement.Entities;

#nullable disable

namespace RestaurantManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class EditedSomeConfigInRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantMenuItems_Restaurants_RestaurantId",
                table: "RestaurantMenuItems");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Restaurants",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<List<DeliveryTime>>(
                name: "DeliveryTime",
                table: "Restaurants",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(List<DeliveryTime>),
                oldType: "jsonb");

            migrationBuilder.AlterColumn<string>(
                name: "ContactPhoneNumber",
                table: "Restaurants",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ContactEmail",
                table: "Restaurants",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<double>(
                name: "AvgRating",
                table: "Restaurants",
                type: "numeric(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Restaurants",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantMenuItems_Restaurants_RestaurantId",
                table: "RestaurantMenuItems",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantMenuItems_Restaurants_RestaurantId",
                table: "RestaurantMenuItems");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Restaurants",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<List<DeliveryTime>>(
                name: "DeliveryTime",
                table: "Restaurants",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(List<DeliveryTime>),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactPhoneNumber",
                table: "Restaurants",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactEmail",
                table: "Restaurants",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AvgRating",
                table: "Restaurants",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "numeric(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Restaurants",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantMenuItems_Restaurants_RestaurantId",
                table: "RestaurantMenuItems",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
