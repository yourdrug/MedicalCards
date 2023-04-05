using MedicalCards.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Repositories.Interfaces
{
    public interface IResearchRepository:IRepository<Research>
    {
        public Task<List<Research>> GetAllResearches();

        public Task<List<Research>> GetResearchesByPatient(int id);
    }

    
}
