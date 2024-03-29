﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime DateTimeAppointment { get; set; }

        public double Price { get; set; }

        public Doctor? Doctor { get; set; }

        public Patient? Patient { get; set; }

        public IEnumerable<PrescriptionOfMedicines>? PrescriptionOfMedicines { get; set; }

    }
}
