using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_acccess_layer.Migrations
{
    /// <inheritdoc />
    public partial class fixedResearch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientResearch");

            migrationBuilder.DropColumn(
                name: "ReserchId",
                table: "Patients");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_PatientId",
                table: "Researches",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Researches_Patients_PatientId",
                table: "Researches",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Researches_Patients_PatientId",
                table: "Researches");

            migrationBuilder.DropIndex(
                name: "IX_Researches_PatientId",
                table: "Researches");

            migrationBuilder.AddColumn<int>(
                name: "ReserchId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PatientResearch",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    ResearchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientResearch", x => new { x.PatientId, x.ResearchId });
                    table.ForeignKey(
                        name: "FK_PatientResearch_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientResearch_Researches_ResearchId",
                        column: x => x.ResearchId,
                        principalTable: "Researches",
                        principalColumn: "ResearchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientResearch_ResearchId",
                table: "PatientResearch",
                column: "ResearchId");
        }
    }
}
