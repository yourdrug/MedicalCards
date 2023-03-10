using MedicalCards.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Repositories
{
    public class QualificationRepository : Repository<Qualification>
    {
        public QualificationRepository(DbContext context) : base(context)
        {
            
        }
    }
}
