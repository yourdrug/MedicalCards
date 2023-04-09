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

        public List<PrescriptionOfMedicines> AddMedicines(List<Medicines> list_medicines, string comment)
        {
            List<PrescriptionOfMedicines> prescriptionOfMedicines = new List<PrescriptionOfMedicines>();
            foreach (var medicine in list_medicines)
            {
                prescriptionOfMedicines.Add(new PrescriptionOfMedicines() {Comment = comment, MedicinesId = medicine.MedicinesId} );
                
            }

            return prescriptionOfMedicines;
        }

        public async Task<List<string>> GetMedicines(List<Appointment> appointments)
        {
            List<string> medicines = new List<string>();
            foreach (var appointment in appointments)
            {
                var temp = await appointmentRepository.GetMedicinesByAppointment(appointment);
                
                string medicines_str = "";
                for(int i =0; i < temp.Count; i++)
                {
                    medicines_str.Concat(temp[i].Name + ", ");
                }
                medicines.Add(medicines_str);
            }

            return medicines;
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

        public async Task<List<Appointment?>?> GetAllAppointments()
        {
            return await appointmentRepository.GetAllWithAllDependencies();
        }

        public async Task<List<Appointment?>?> GetAppointmentsByDoctor(int id)
        {
            return await appointmentRepository.GetAppointmentsByDoctor(id);
        }

        public async Task<List<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await appointmentRepository.GetAppointmentsByPatient(id);
        }

        public List<PrescriptionOfMedicines> GetPrescriptionOfMedicines(List<Medicines> list_medicines)
        {
            List<PrescriptionOfMedicines> prescriptionOfMedicines = new List<PrescriptionOfMedicines>();
            foreach (var medicine in list_medicines)
            {
                prescriptionOfMedicines.Add(new PrescriptionOfMedicines() { Comment = "Всё хорошо", MedicinesId = medicine.MedicinesId });

            }

            return prescriptionOfMedicines;
        }

        public void Dispose()
        {
            prescriptionOfMedicinesRepository.Dispose();
            appointmentRepository.Dispose();
            medicinesRepository.Dispose();
        }
    }
}
