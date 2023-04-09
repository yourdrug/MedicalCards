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
            var diagnosis = await set.Include(d=>d.Doctor).Include(d=>d.Doctor).SingleAsync(d => d.PatientId == id);
            if (diagnosis == null)
            {
                throw new Exception("No diagnosis");
            }

            else
            {
                return diagnosis;
            }
        }

        public async Task<List<Diagnosis?>?> GetByDoctorWithAllDependencies(int id)
        {
            return await set.Where(d => d.DoctorId == id).Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
        }
    }
}
