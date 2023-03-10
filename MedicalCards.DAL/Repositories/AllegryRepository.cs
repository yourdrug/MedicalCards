using MedicalCards.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Repositories
{
    public class AllegryRepository : Repository<Allergy>
    {
        public AllegryRepository(DbContext context) : base (context)
        {
            
        }
    }
}
