using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.BLL.Services
{
    public class PrescriptionOfMedicinesService : IDisposable
    {
        private readonly IPrescriptionOfMedicinesRepository prescriptionOfMedicinesRepository;
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IMedicinesRepository medicinesRepository;

        public PrescriptionOfMedicinesService(IPrescriptionOfMedicinesRepository prescriptionOfMedicinesRepository, IAppointmentRepository appointmentRepository, IMedicinesRepository medicinesRepository)
        {
            this.prescriptionOfMedicinesRepository = prescriptionOfMedicinesRepository;
            this.appointmentRepository = appointmentRepository;
            this.medicinesRepository = medicinesRepository;
        }

        public async Task<PrescriptionOfMedicines> GetAppointmentWithMedicines(int id)
        {
            return await prescriptionOfMedicinesRepository.GetByIdWithAllDependencies(id);
        }

        public List<PrescriptionOfMedicines> AddMedicines(List<Medicines> list_medicines)
        {
            List<PrescriptionOfMedicines> prescriptionOfMedicines = new List<PrescriptionOfMedicines>();
            foreach (var medicine in list_medicines)
            {
                prescriptionOfMedicines.Add(new PrescriptionOfMedicines() {Comment = "Всё хорошо", MedicinesId = medicine.MedicinesId} );
                
            }

            return prescriptionOfMedicines;
        }

        public void CreateAppointment(double price, DateTime dateTime, List<PrescriptionOfMedicines> temp_medicines, Doctor doctor, Patient patient)
        {
            var temp_appointment = new Appointment();
            temp_appointment.PatientId = patient.PatientId;
            temp_appointment.DoctorId = doctor.DoctorId;
            temp_appointment.DateTimeAppointment = dateTime;
            temp_appointment.PrescriptionOfMedicines = temp_medicines;
            temp_appointment.Price = price;
            appointmentRepository.Create(temp_appointment);
            appointmentRepository.Save();
        }

        public async Task<Medicines> GetMedicineById(int id)
        {
            return await medicinesRepository.GetById(id);
        }

        public async Task<Array> GetAllMedicines()
        {
            return (Array)await medicinesRepository.GetAll();
        }

        public async Task<List<Appointment>> GetAllAppointments()
        {
            return await appointmentRepository.GetAllWithAllDependencies();
        }

        public void Dispose()
        {
            prescriptionOfMedicinesRepository.Dispose();
            appointmentRepository.Dispose();
            medicinesRepository.Dispose();
        }
    }
}
