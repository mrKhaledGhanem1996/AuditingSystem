using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditingSystem.Database.Migrations
{
    public partial class ChangeFieldIdAsAName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Industries_Industries_ParentIndustryId",
                table: "Industries");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Industries");

            migrationBuilder.AlterColumn<int>(
                name: "ParentIndustryId",
                table: "Industries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Industries_Industries_ParentIndustryId",
                table: "Industries",
                column: "ParentIndustryId",
                principalTable: "Industries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Industries_Industries_ParentIndustryId",
                table: "Industries");

            migrationBuilder.AlterColumn<int>(
                name: "ParentIndustryId",
                table: "Industries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Industries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Industries_Industries_ParentIndustryId",
                table: "Industries",
                column: "ParentIndustryId",
                principalTable: "Industries",
                principalColumn: "Id");
        }
    }
}
