using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AttachmentsUpd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "UserAttachment",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Attachments",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "UserAttachment");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Attachments");
        }
    }
}
