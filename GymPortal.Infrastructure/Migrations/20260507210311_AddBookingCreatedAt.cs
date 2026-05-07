using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymPortal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingCreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookedAt",
                table: "Bookings",
                newName: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GymClassId",
                table: "Bookings",
                column: "GymClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_GymClasses_GymClassId",
                table: "Bookings",
                column: "GymClassId",
                principalTable: "GymClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_GymClasses_GymClassId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_GymClassId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Bookings",
                newName: "BookedAt");
        }
    }
}
