using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditingSystem.Database.Migrations
{
    public partial class changeAssessmentRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiskAssessments");

            migrationBuilder.DropColumn(
                name: "ControlId",
                table: "RiskIdentifications");

            migrationBuilder.CreateTable(
                name: "RiskAssessmentsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RiskIdentificationId = table.Column<int>(type: "int", nullable: false),
                    ControlId = table.Column<int>(type: "int", nullable: false),
                    ResidualRiskRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiskAssessmentListId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskAssessmentsList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskAssessmentsList_Controls_ControlId",
                        column: x => x.ControlId,
                        principalTable: "Controls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RiskAssessmentsList_RiskAssessmentsList_RiskAssessmentListId",
                        column: x => x.RiskAssessmentListId,
                        principalTable: "RiskAssessmentsList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RiskAssessmentsList_RiskIdentifications_RiskIdentificationId",
                        column: x => x.RiskIdentificationId,
                        principalTable: "RiskIdentifications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Controls_RiskIdentificationId",
                table: "Controls",
                column: "RiskIdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskAssessmentsList_ControlId",
                table: "RiskAssessmentsList",
                column: "ControlId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskAssessmentsList_RiskAssessmentListId",
                table: "RiskAssessmentsList",
                column: "RiskAssessmentListId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskAssessmentsList_RiskIdentificationId",
                table: "RiskAssessmentsList",
                column: "RiskIdentificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Controls_RiskIdentifications_RiskIdentificationId",
                table: "Controls",
                column: "RiskIdentificationId",
                principalTable: "RiskIdentifications",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Controls_RiskIdentifications_RiskIdentificationId",
                table: "Controls");

            migrationBuilder.DropTable(
                name: "RiskAssessmentsList");

            migrationBuilder.DropIndex(
                name: "IX_Controls_RiskIdentificationId",
                table: "Controls");

            migrationBuilder.AddColumn<int>(
                name: "ControlId",
                table: "RiskIdentifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RiskAssessments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControlId = table.Column<int>(type: "int", nullable: false),
                    RiskIdentificationId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidualRiskRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiskAssessmentId = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskAssessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskAssessments_Controls_ControlId",
                        column: x => x.ControlId,
                        principalTable: "Controls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RiskAssessments_RiskAssessments_RiskAssessmentId",
                        column: x => x.RiskAssessmentId,
                        principalTable: "RiskAssessments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RiskAssessments_RiskIdentifications_RiskIdentificationId",
                        column: x => x.RiskIdentificationId,
                        principalTable: "RiskIdentifications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RiskAssessments_ControlId",
                table: "RiskAssessments",
                column: "ControlId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskAssessments_RiskAssessmentId",
                table: "RiskAssessments",
                column: "RiskAssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskAssessments_RiskIdentificationId",
                table: "RiskAssessments",
                column: "RiskIdentificationId");
        }
    }
}
