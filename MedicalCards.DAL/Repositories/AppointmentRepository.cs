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
            await entry.Collection(a=>a.PrescriptionOfMedicines).LoadAsync();
            return (List<Medicines?>?)entry.Entity?.PrescriptionOfMedicines?.Select(m => m.Medicines);
        }

        public async Task<List<Appointment?>?> GetAllWithAllDependencies()
        {
            return await set.Include(a => a.Doctor).Include(a => a.Patient).Include(a => a.PrescriptionOfMedicines).ToListAsync();
        }
    }
}
