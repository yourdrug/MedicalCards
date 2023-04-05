using MedicalCards.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Repositories.Interfaces
{
    public interface IAppointmentRepository:IRepository<Appointment>
    {
        public Task<List<Medicines?>?> GetMedicinesByAppointment(Appointment appointment);

        public Task<List<Appointment?>?> GetAllWithAllDependencies();

        public Task<List<Appointment?>?> GetAppointmentsByDoctor(int id);

        public Task<List<Appointment?>?> GetAppointmentsByPatient(int id);

    }
}
