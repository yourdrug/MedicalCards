using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Entities
{
    public class User
    {
        public enum RoleType
        {
            Admin = 1,
            Patient,
            Doctor
        };


        public enum AccessType
        {
            Blocked = -1,
            UnderInvestigation,
            Active
        };

        public int UserId { get; set; }

        [MaxLength(20)]
        public string Login { get; set; } = null!;

        [MaxLength(70)]
        public string Hash { get; set; } = null!;

        public RoleType Role { get; set; }

        public AccessType Access { get; set; }
    }
}
