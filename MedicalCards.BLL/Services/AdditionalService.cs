using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.BLL.Services
{
    public class AdditionalService: IDisposable
    {
        private readonly IFeaturesRepository featuresRepository;
        private readonly IAllergyRepository allergyRepository;

        public AdditionalService(IFeaturesRepository featuresRepository, IAllergyRepository allergyRepository)
        {
            this.featuresRepository = featuresRepository;
            this.allergyRepository = allergyRepository;
        }

        public async void AddFeaturesToPatient(Features features)
        {
            Features temp_features = await featuresRepository.Create(features);
            featuresRepository.Save();
        }

        public async void AddAllergyToPatient(Allergy allergy)
        {
            Allergy temp_features = await allergyRepository.Create(allergy);
            allergyRepository.Save();
        }

        public void Dispose()
        {
            featuresRepository.Dispose();
            allergyRepository.Dispose();
    }
}
        }
