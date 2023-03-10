using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_acccess_layer.Entities
{
    public class Address
    {
        public int AddressId { get; set; }

        [MaxLength(50)]
        public string City { get; set; } = null!;

        [MaxLength(50)]
        public string Street { get; set; } = null!;

        public int HouseNumber { get; set; }

        public int FlatNumber { get; set; }


        public IEnumerable<Doctor>? Doctor { get; set; }
        public IEnumerable<Patient>? Patient { get; set; }

    }
}
