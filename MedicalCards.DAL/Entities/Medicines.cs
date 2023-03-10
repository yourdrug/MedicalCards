using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_acccess_layer.Entities
{
    public class Medicines
    {
        public int MedicinesId { get; set; }


        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [MaxLength(100)]
        public string? Comment { get; set; }

        public decimal Price { get; set; }


        public IEnumerable<PrescriptionOfMedicines>? PrescriptionOfMedicines { get; set; }
    }
}
