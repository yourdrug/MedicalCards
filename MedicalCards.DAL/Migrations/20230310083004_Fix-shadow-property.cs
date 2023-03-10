using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_acccess_layer.Migrations
{
    /// <inheritdoc />
    public partial class Fixshadowproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Doctors_PatientId",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Patients_PatientId1",
                table: "Diagnoses");

            migrationBuilder.DropIndex(
                name: "IX_Diagnoses_PatientId",
                table: "Diagnoses");

            migrationBuilder.DropIndex(
                name: "IX_Diagnoses_PatientId1",
                table: "Diagnoses");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Diagnoses");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_DoctorId",
                table: "Diagnoses",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_PatientId",
                table: "Diagnoses",
                column: "PatientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Doctors_DoctorId",
                table: "Diagnoses",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Patients_PatientId",
                table: "Diagnoses",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Doctors_DoctorId",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Patients_PatientId",
                table: "Diagnoses");

            migrationBuilder.DropIndex(
                name: "IX_Diagnoses_DoctorId",
                table: "Diagnoses");

            migrationBuilder.DropIndex(
                name: "IX_Diagnoses_PatientId",
                table: "Diagnoses");

            migrationBuilder.AddColumn<int>(
                name: "PatientId1",
                table: "Diagnoses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_PatientId",
                table: "Diagnoses",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_PatientId1",
                table: "Diagnoses",
                column: "PatientId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Doctors_PatientId",
                table: "Diagnoses",
                column: "PatientId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Patients_PatientId1",
                table: "Diagnoses",
                column: "PatientId1",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
