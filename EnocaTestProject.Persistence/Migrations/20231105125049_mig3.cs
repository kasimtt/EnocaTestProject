using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnocaTestProject.Persistence.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carriers_CarrierConfigurations_CarrierConfigrationId",
                table: "Carriers");

            migrationBuilder.DropIndex(
                name: "IX_Carriers_CarrierConfigrationId",
                table: "Carriers");

            migrationBuilder.DropColumn(
                name: "CarrierConfigrationId",
                table: "Carriers");

            migrationBuilder.AddColumn<int>(
                name: "CarrierId",
                table: "CarrierConfigurations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarrierConfigurations_CarrierId",
                table: "CarrierConfigurations",
                column: "CarrierId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarrierConfigurations_Carriers_CarrierId",
                table: "CarrierConfigurations",
                column: "CarrierId",
                principalTable: "Carriers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrierConfigurations_Carriers_CarrierId",
                table: "CarrierConfigurations");

            migrationBuilder.DropIndex(
                name: "IX_CarrierConfigurations_CarrierId",
                table: "CarrierConfigurations");

            migrationBuilder.DropColumn(
                name: "CarrierId",
                table: "CarrierConfigurations");

            migrationBuilder.AddColumn<int>(
                name: "CarrierConfigrationId",
                table: "Carriers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carriers_CarrierConfigrationId",
                table: "Carriers",
                column: "CarrierConfigrationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carriers_CarrierConfigurations_CarrierConfigrationId",
                table: "Carriers",
                column: "CarrierConfigrationId",
                principalTable: "CarrierConfigurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
