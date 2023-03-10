using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_acccess_layer.Entities
{
    public class User
    {
        public int UserId { get; set; }

        [MaxLength(20)]
        public string Login { get; set; } = null!;

        [MaxLength(50)]
        public string Hash { get; set; } = null!;

        [MaxLength(50)]
        public string Salt { get; set; } = null!;

        [MaxLength(20)]
        public string Role { get; set; } = null!;
    }
}
