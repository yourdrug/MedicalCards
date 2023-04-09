using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Repositories
{
    public class AppointmentRepository : Repository<Appointment>,IAppointmentRepository
    {
        public AppointmentRepository(AppContext context) : base(context)
        {
            
        }

        public async Task<List<Medicines?>?> GetMedicinesByAppointment(Appointment appointment)
        {

            var entry = set.Entry(appointment);
            await entry.Collection(a => a.PrescriptionOfMedicines).LoadAsync();
            return entry.Entity?.PrescriptionOfMedicines?.Select(m => m.Medicines).ToList();
        }


        public async Task<List<Appointment?>?> GetAllWithAllDependencies()
        {
            var appointments = await set.Include(a => a.Doctor).Include(a => a.Patient).Include(a => a.PrescriptionOfMedicines).ToListAsync();
            return appointments;
        }

        public async Task<List<Appointment?>?> GetAppointmentsByDoctor(int id)
        {
            var appointments = await set.Where(d=>d.DoctorId == id)
                                                        .Include(a => a.Doctor)
                                                        .Include(a => a.Patient)
                                                        .Include(a => a.PrescriptionOfMedicines).ToListAsync();
            return appointments;
        }

        public async Task<List<Appointment?>?> GetAppointmentsByPatient(int id)
        {
            var appointments = await set.Where(d => d.PatientId == id)
                                                        .Include(a => a.Doctor)
                                                        .Include(a => a.Patient)
                                                        .Include(a => a.PrescriptionOfMedicines).ToListAsync();
            return appointments;
        }
    }
}
