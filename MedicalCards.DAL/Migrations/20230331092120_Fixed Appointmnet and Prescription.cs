using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCards.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixedAppointmnetandPrescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfAppointment",
                table: "PrescriptionOfMedicines");

            migrationBuilder.DropColumn(
                name: "FinishAppointment",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "StartAppointment",
                table: "Appointments",
                newName: "DateTimeAppointment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimeAppointment",
                table: "Appointments",
                newName: "StartAppointment");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfAppointment",
                table: "PrescriptionOfMedicines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishAppointment",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
