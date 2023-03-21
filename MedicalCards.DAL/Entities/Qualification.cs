using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Entities
{
    public class Qualification
    {
        public int QualificationId { get; set; }

        [MaxLength(70)]
        public string NameOfSpeciality { get; set; } = null!;

        public int WorkExperience { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime FinishDate { get; set; }

        public int DoctorId { get; set; }

        public Doctor? Doctor { get; set; }
    }
}
