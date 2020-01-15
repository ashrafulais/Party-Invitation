using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyInvite.Migrations
{
    public partial class RemoveConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestResponses_Gifts_GiftId",
                table: "GuestResponses");

            migrationBuilder.DropIndex(
                name: "IX_GuestResponses_GiftId",
                table: "GuestResponses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GuestResponses_GiftId",
                table: "GuestResponses",
                column: "GiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestResponses_Gifts_GiftId",
                table: "GuestResponses",
                column: "GiftId",
                principalTable: "Gifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
