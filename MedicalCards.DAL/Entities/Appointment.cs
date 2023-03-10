using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_acccess_layer.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime StartAppointment { get; set; }

        public DateTime FinishAppointment { get; set; }

        public double Price { get; set; }


        public Doctor? Doctor { get; set; }

        public Patient? Patient { get; set; }

        public IEnumerable<PrescriptionOfMedicines>? PrescriptionOfMedicines { get; set; }

    }
}
