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
    public class DoctorRepository : Repository<Doctor>,IDoctorRepository
    {
        public DoctorRepository(AppContext context) : base(context)
        {
            
        }

        public async Task<Doctor> GetByIdWithAllDependencies(int id)
        {
            var doctor = await set.Include(p => p.Appointment).Include(p => p.Diagnosis).Include(p=>p.Qualification).SingleAsync(p=>p.DoctorId == id);

            if (doctor == null)
            {
                throw new Exception("No doctor by this id");
            }

            else
            {
                return doctor;            
            }

        }
    }
}
