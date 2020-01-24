using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyInvite.Migrations
{
    public partial class IndividualGift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiftId",
                table: "GuestResponses");

            migrationBuilder.AddColumn<string>(
                name: "GiftName",
                table: "GuestResponses",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiftName",
                table: "GuestResponses");

            migrationBuilder.AddColumn<int>(
                name: "GiftId",
                table: "GuestResponses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
