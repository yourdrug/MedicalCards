using MedicalCards.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Repositories.Interfaces
{
    public interface IAddressRepository:IRepository<Address>
    {
        Task<bool> isUniqueAdress(Address address);

        Task<Address> FindByCredits(Address address);
    }
}
