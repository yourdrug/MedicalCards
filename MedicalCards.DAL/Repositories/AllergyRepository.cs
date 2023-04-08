using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Repositories
{
    public class AllergyRepository : Repository<Allergy>,IAllergyRepository
    {
        public AllergyRepository(AppContext context) : base (context)
        {
            
        }

        public async Task<List<Allergy>> GetAllergiesByPatient(int id)
        {
            var allergies = await set.Where(a => a.PatientId == id).ToListAsync();
            return allergies;
        }
    }
}
