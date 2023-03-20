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
                patient.AddressId = Address.AddressId;
            }

            else
            {
                var Address = await addressRepository.FindByCredits(address);
                patient.AddressId = Address.AddressId;
            }
            
            
            var patient1 = await patientRepository.Create(patient);
            return patient1;
        }

        public void Dispose()
        {
            patientRepository.Dispose();
        }
    }
}
