using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Entities
{
    public class PrescriptionOfMedicines
    {
        public int AppointmentId { get; set; }

        public int MedicinesId { get; set; }

        [MaxLength(100)]
        public string Comment { get; set; } = null!;


        public Medicines? Medicines { get; set; }

        public Appointment? Appointment { get; set; }

    }

}
