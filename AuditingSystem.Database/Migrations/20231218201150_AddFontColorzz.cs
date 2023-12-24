using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditingSystem.Database.Migrations
{
    public partial class AddFontColorzz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FontColor",
                table: "ControlTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FontColor",
                table: "ControlProcesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FontColor",
                table: "ControlFrequencies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FontColor",
                table: "ControlEffectivenesses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FontColor",
                table: "ControlTypes");

            migrationBuilder.DropColumn(
                name: "FontColor",
                table: "ControlProcesses");

            migrationBuilder.DropColumn(
                name: "FontColor",
                table: "ControlFrequencies");

            migrationBuilder.DropColumn(
                name: "FontColor",
                table: "ControlEffectivenesses");
        }
    }
}
