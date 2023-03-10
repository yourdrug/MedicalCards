using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_acccess_layer.Entities
{
    public class Qualification
    {
        public int QualificationId { get; set; }

        [MaxLength(70)]
        public string NameOfSpeciality { get; set; } = null!;

        public int WorkExperience { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public int DoctorId { get; set; }

        public Doctor? Doctor { get; set; }
    }
}
