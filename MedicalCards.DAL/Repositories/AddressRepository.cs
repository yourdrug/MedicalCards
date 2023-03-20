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

        public async Task<Address> FindByCredits(Address address)
        {
            return await set.SingleAsync(Address => Address.City == address.City &
                                                      Address.Street == address.Street &
                                                      Address.HouseNumber == address.HouseNumber &
                                                      Address.FlatNumber == address.FlatNumber);
        }

        public async Task<bool> isUniqueAdress(Address address)
        {
            return !await _context.Addresses.AnyAsync(Address => Address.City == address.City &
                                                      Address.Street == address.Street &
                                                      Address.HouseNumber == address.HouseNumber &
                                                      Address.FlatNumber == address.FlatNumber);
        }
    }
}
