using System;
using MedicalCards.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MedicalCards.DAL.Repositories
{
    public class AddressRepository: Repository<Address>
    {
        public AddressRepository(DbContext context) : base(context)
        {
            
        }
    }
}
