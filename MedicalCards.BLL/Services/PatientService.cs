using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.BLL.Services
{
    public class PatientService: IDisposable
    {
        private readonly IPatientRepository patientRepository;
        private readonly IAddressRepository addressRepository;

        public PatientService(IPatientRepository patientRepository, IAddressRepository addressRepository)
        {
            this.patientRepository = patientRepository;
            this.addressRepository = addressRepository;
        }

        public async Task<Patient> SignAsPatient(Patient patient, Address address)
        {

            if(await addressRepository.isUniqueAdress(address))
            {
                var Address = await addressRepository.Create(address);
                addressRepository.Save();
                patient.AddressId = Address.AddressId;
            }

            else
            {
                var Address = await addressRepository.FindByCredits(address);
                patient.AddressId = Address.AddressId;
            }
            
            
            var patient1 = await patientRepository.Create(patient);
            patientRepository.Save();
            return patient1;
        }

        public async Task<Patient> GetPatient(int id)
        {
            try
            {
                return await patientRepository.GetById(id);
            }
            
            catch(Exception)
            {
                throw new Exception("No patient by this id");
            }
        }

        public async Task<Array> GetAll()
        {
            return (Array)await patientRepository.GetAll();
        }

        public void Dispose()
        {
            patientRepository.Dispose();
            addressRepository.Dispose();
        }
    }
}
