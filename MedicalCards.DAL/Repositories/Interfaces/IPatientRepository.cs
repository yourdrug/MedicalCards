using MedicalCards.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Repositories.Interfaces
{
    public interface IPatientRepository:IRepository<Patient>
    {
        Task<Patient> GetByIdWithAllDependencies(int id);
    }
}
