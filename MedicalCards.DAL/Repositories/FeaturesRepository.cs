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
    public class FeaturesRepository : Repository<Features>,IFeaturesRepository
    {
        public FeaturesRepository(AppContext context) : base (context)
        {
            
        }

        public async Task<Features> GetFeaturesByPatient(int id)
        {
            var features = await set.SingleAsync(f => f.PatientId == id);

            if (features == null)
            {
                throw new Exception("No patients features");
            }

            else
            {
                return features;
            }
        }

        public async Task<bool> isUniqueFeatures(int id)
        {
            return !await _context.Features.AnyAsync(f=>f.PatientId == id);
        }
    }
}
