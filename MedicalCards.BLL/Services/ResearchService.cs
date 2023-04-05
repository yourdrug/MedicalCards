using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories;
using MedicalCards.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.BLL.Services
{
    public class ResearchService: IDisposable
    {
        private readonly IResearchRepository researchRepository;

        public ResearchService(IResearchRepository researchRepository)
        {
            this.researchRepository = researchRepository;
        }

        public async Task<List<Research>> GetPatientResearches(int id)
        {
            var researches = await researchRepository.GetResearchesByPatient(id);
            return researches;
        }

        public async Task<List<Research>> GetAllResearches()
        {
            var researches = await researchRepository.GetAllResearches();
            return researches;
        }

        public async void CreateNewResearch(Research research)
        {
            var temp = await researchRepository.Create(research);
            researchRepository.Save();
        }

        public void Dispose()
        {
            researchRepository.Dispose();
        }
    }
}
