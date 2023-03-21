using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Entities
{
    public class Diagnosis
    {
        public int DiagnosisId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public int DoctorId { get; set; }
        
        public int PatientId { get; set; }

        [MaxLength(50)]
        public string Comment { get; set; } = null!;

        [Column(TypeName = "date")]
        public DateTime DateOfDiagnosis { get; set; }

        public Doctor? Doctor { get; set; }

        public Patient? Patient { get; set; }

    }
}
