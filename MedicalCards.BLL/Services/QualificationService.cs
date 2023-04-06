using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.BLL.Services
{
    public class QualificationService:IDisposable
    {
        private readonly IQualificationRepository qualificationRepository;

        public QualificationService(IQualificationRepository qualificationRepository)
        {
            this.qualificationRepository = qualificationRepository;
        }
            
        public async void CreateQualification(Qualification qualification) 
        {
            await qualificationRepository.Create(qualification);
            qualificationRepository.Save();
        }

        public void Dispose()
        {
            qualificationRepository.Dispose();
        }
    }
}
