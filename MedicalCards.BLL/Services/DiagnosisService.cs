using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.BLL.Services
{
    public class DiagnosisService:IDisposable
    {
        private readonly IDiagnosisRepository diagnosisRepository;
        private readonly IDoctorRepository doctorRepository;

        public DiagnosisService(IDiagnosisRepository diagnosisRepository, IDoctorRepository doctorRepository)
        {
            this.diagnosisRepository = diagnosisRepository;
            this.doctorRepository = doctorRepository;
        }

        public async void AddDiagnosis(Diagnosis diagnosis)
        {
            Diagnosis temp_diagnosis = await diagnosisRepository.Create(diagnosis);
            diagnosisRepository.Save();
        }

        public async Task<List<Diagnosis>> GetDiagnosisByDoctor(int id)
        {
            var diagnoses_list = await diagnosisRepository.GetByDoctorWithAllDependencies(id);
            return diagnoses_list;
        }

        public async Task<Diagnosis> GetDiagnosisByPatient(int id)
        {
            try
            {
                var diagnosis = await diagnosisRepository.GetByPatient(id);
                return diagnosis;
            }

            catch(Exception)
            {
                throw new Exception("No diagnosis by this patient");
            }
            
        }

        public async Task<Doctor> GetDoctorByDiagnosis(int id)
        {
            return await doctorRepository.GetById(id);
        }

        public void Dispose()
        {
            diagnosisRepository.Dispose();
        }
    }
}
