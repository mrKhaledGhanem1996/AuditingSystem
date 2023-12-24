using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditingSystem.Database.Migrations
{
    public partial class Initial_RiskAssessment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Controls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControlTypeId = table.Column<int>(type: "int", nullable: false),
                    ControlProcessId = table.Column<int>(type: "int", nullable: false),
                    ControlFrequencyId = table.Column<int>(type: "int", nullable: false),
                    ControlEffectivenessId = table.Column<int>(type: "int", nullable: false),
                    RiskIdentificationId = table.Column<int>(type: "int", nullable: false),
                    ControlEffectivenessRating = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Controls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Controls_ControlEffectivenesses_ControlEffectivenessId",
                        column: x => x.ControlEffectivenessId,
                        principalTable: "ControlEffectivenesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Controls_ControlFrequencies_ControlFrequencyId",
                        column: x => x.ControlFrequencyId,
                        principalTable: "ControlFrequencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Controls_ControlProcesses_ControlProcessId",
                        column: x => x.ControlProcessId,
                        principalTable: "ControlProcesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Controls_ControlTypes_ControlTypeId",
                        column: x => x.ControlTypeId,
                        principalTable: "ControlTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RiskIdentifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RiskCategoryId = table.Column<int>(type: "int", nullable: false),
                    RiskImpactId = table.Column<int>(type: "int", nullable: false),
                    RiskLikelihoodId = table.Column<int>(type: "int", nullable: false),
                    InherentRiskRating = table.Column<int>(type: "int", nullable: false),
                    RiskRatingRationalization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_RiskIdentifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskIdentifications_RiskCategories_RiskCategoryId",
                        column: x => x.RiskCategoryId,
                        principalTable: "RiskCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RiskIdentifications_RiskImpacts_RiskImpactId",
                        column: x => x.RiskImpactId,
                        principalTable: "RiskImpacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RiskIdentifications_RiskLikehoods_RiskLikelihoodId",
                        column: x => x.RiskLikelihoodId,
                        principalTable: "RiskLikehoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RiskAssessments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RiskIdentificationId = table.Column<int>(type: "int", nullable: false),
                    ControlId = table.Column<int>(type: "int", nullable: false),
                    ResidualRiskRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiskAssessmentId = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Controls_ControlEffectivenessId",
                table: "Controls",
                column: "ControlEffectivenessId");

            migrationBuilder.CreateIndex(
                name: "IX_Controls_ControlFrequencyId",
                table: "Controls",
                column: "ControlFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Controls_ControlProcessId",
                table: "Controls",
                column: "ControlProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Controls_ControlTypeId",
                table: "Controls",
                column: "ControlTypeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_RiskIdentifications_RiskCategoryId",
                table: "RiskIdentifications",
                column: "RiskCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskIdentifications_RiskImpactId",
                table: "RiskIdentifications",
                column: "RiskImpactId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskIdentifications_RiskLikelihoodId",
                table: "RiskIdentifications",
                column: "RiskLikelihoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiskAssessments");

            migrationBuilder.DropTable(
                name: "Controls");

            migrationBuilder.DropTable(
                name: "RiskIdentifications");
        }
    }
}
