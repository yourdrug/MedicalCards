using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Entities
{
    public class Allergy
    {
        public int AllergyId { get; set; }

        public int PatientId { get; set; }

        [MaxLength(50)]
        public string Allergen { get; set; } = null!;

        [MaxLength(50)]
        public string Reaction { get; set; } = null!;

        [MaxLength(50)]
        public string Severity { get; set; } = null!;


        public Patient? Patient { get; set; }

    }
}
