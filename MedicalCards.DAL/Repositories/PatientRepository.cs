using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Repositories
{
    public class PatientRepository : Repository<Patient>,IPatientRepository
    {
        
        public PatientRepository(AppContext context) : base (context)
        {
            
        }

        public async Task<Patient> GetByIdWithAllDependencies(int id)
        {
            var patient =  await set.Include(p => p.Research)
                      .Include(p => p.Allergy)
                      .Include(p => p.Appointment)
                      .Include(p => p.Diagnosis).SingleAsync(p => p.PatientId == id);

            if (patient == null)
            {
                throw new Exception("No patient by this id");
            }

            else
            {
                return patient;
            }
        }

    }
}
