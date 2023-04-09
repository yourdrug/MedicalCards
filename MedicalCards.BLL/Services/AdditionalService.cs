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

        public async void AddFeaturesToPatient(Features features, int id)
        {
            if(await featuresRepository.isUniqueFeatures(id))
            {
                features.PatientId = id;
                Features temp_features = await featuresRepository.Create(features);
                featuresRepository.Save();
            }

            else
            {
                var temp = await featuresRepository.GetFeaturesByPatient(id);
                temp.Height = features.Height;
                temp.Weight = features.Weight;
                temp.Pulse = features.Pulse;
                temp.UpPressure = features.UpPressure;
                temp.DownPressure = features.DownPressure;
                temp.BMI = features.BMI;
                temp.Сholesterol = features.Сholesterol;
                var updated = await featuresRepository.Update(temp);
            }
            
        }

        public async void AddAllergyToPatient(Allergy allergy)
        {
            Allergy temp_features = await allergyRepository.Create(allergy);
            allergyRepository.Save();
        }

        public async Task<List<Allergy>> GetAllergies(int id)
        {
            return await allergyRepository.GetAllergiesByPatient(id);
        }

        public void Dispose()
        {
            featuresRepository.Dispose();
            allergyRepository.Dispose();
    
        }

    }
        
}
