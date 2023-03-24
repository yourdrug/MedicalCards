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
    public class DoctorService : IDisposable
    {
        private readonly IDoctorRepository doctorRepository;
        private readonly IAddressRepository addressRepository;

        public DoctorService(IDoctorRepository doctorRepository, IAddressRepository addressRepository)
        {
            this.doctorRepository = doctorRepository;
            this.addressRepository = addressRepository;
        }


        public async Task<Doctor> SignAsDoctor(Doctor doctor, Address address)
        {

            if (await addressRepository.isUniqueAdress(address))
            {
                var Address = await addressRepository.Create(address);
                await addressRepository.Save();
                doctor.AddressId = Address.AddressId;
            }

            else
            {
                var Address = await addressRepository.FindByCredits(address);
                doctor.AddressId = Address.AddressId;
            }


            var temp_doctor = await doctorRepository.Create(doctor);
            await doctorRepository.Save();
            return temp_doctor;
        }


        public void Dispose()
        {
            doctorRepository.Dispose();
            addressRepository.Dispose();
        }
    }
}
