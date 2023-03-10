using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_acccess_layer.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }


        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [MaxLength(50)]
        public string Patronymic { get; set; } = null!;

        [MaxLength(20)]
        public string PhoneNumber { get; set; } = null!;

        [MaxLength(10)]
        public string Sex { get; set; } = null!;

        public int AddressId { get; set; }

        public DateTime DateOfBirth { get; set; }



        [ForeignKey("DoctorId")]
        public User? User { get; set; }
        
        public Address? Address { get; set; }

        public IEnumerable<Diagnosis>? Diagnosis { get; set; }

        public IEnumerable<Appointment>? Appointment { get; set; }

        public Qualification? Qualification { get; set; }
    }
}
