using System;
using MedicalCards.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MedicalCards.DAL.Repositories.Interfaces;

namespace MedicalCards.DAL.Repositories
{
    public class AddressRepository: Repository<Address>,IAddressRepository
    {
        public AddressRepository(AppContext context) : base(context)
        {
            
        }
    }
}
