using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Entities
{
    public class Research
    {
        public int ResearchId { get; set; }

        public int PatientId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [MaxLength(50)]
        public string TypeOfResearch { get; set; } = null!;

        [MaxLength(50)]
        public string ShortResult { get; set; } = null!;

        [MaxLength(255)]
        public string Result { get; set; } = null!;

        [MaxLength(100)]
        public string? Comment { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfResearch { get; set; }


    }
}
