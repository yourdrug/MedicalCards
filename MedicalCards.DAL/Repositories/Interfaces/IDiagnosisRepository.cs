using MedicalCards.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Repositories.Interfaces
{
    public interface IDiagnosisRepository:IRepository<Diagnosis>
    {
        public Task<Diagnosis> GetByPatient(int id);

        public Task<List<Diagnosis?>?> GetByDoctorWithAllDependencies(int id);
    }
}
