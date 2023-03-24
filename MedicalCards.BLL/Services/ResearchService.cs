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

        public async Task<Array> GetResearches(Patient patient)
        {
            var temp = await researchRepository.GetAllByPredicate(research => research.PatientId == patient.PatientId);
            return temp.ToArray();
            //return (Array)await researchRepository.GetAll();
        }

        public async Task<Research> CreateNewResearch(Research research)
        {
            var temp = await researchRepository.Create(research);
            return temp;
            //return (Array)await researchRepository.GetAll();
        }

        public void Dispose()
        {
            researchRepository.Dispose();
        }
    }
}
