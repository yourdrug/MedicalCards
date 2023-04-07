using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Repositories
{
    public class DiagnosisRepository : Repository<Diagnosis>,IDiagnosisRepository
    {
        public DiagnosisRepository(AppContext context) : base(context)
        {
            
        }

        public async Task<Diagnosis> GetByPatient(int id)
        {
            return await set.SingleAsync(d => d.PatientId == id);
        }

        public async Task<List<Diagnosis?>?> GetByDoctorWithAllDependencies(int id)
        {
            return await set.Include(a => a.Doctor).Include(a => a.Patient).Where(d => d.DoctorId == id).ToListAsync();
        }
    }
}
