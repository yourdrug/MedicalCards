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
    public class FeaturesService:IDisposable
    {
        private readonly IFeaturesRepository featuresRepository;

        public FeaturesService(IFeaturesRepository featuresRepository)
        {
            this.featuresRepository = featuresRepository;
        }

        public async Task<Features> GetFeaturesByPatient(int id)
        {
            var features = await featuresRepository.GetFeaturesByPatient(id);
            return features;
        }

        public void Dispose()
        {
            featuresRepository.Dispose();
        }
    }
}
