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
    public class ResearchRepository : Repository<Research>,IResearchRepository
    {
        public ResearchRepository(AppContext context) : base(context)
        {
            
        }

        
        public async Task<List<Research>> GetAllResearches()
        {
            var researches = await set.Include(r => r.Patient).ToListAsync();
            return researches;
        }

        public async Task<List<Research>> GetResearchesByPatient(int id)
        {
            var researches = await set.Include(r => r.Patient).Where(r => r.PatientId == id).ToListAsync();
            return researches;

        }

    }
}
