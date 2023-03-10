using Data_acccess_layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_acccess_layer.Repositories
{
    public class PatientRepository : IRepository<Patient>
    {
        private AppContext db;

        public PatientRepository()
        {
            this.db = new AppContext();
        }

        public IEnumerable<Patient> GetAll()
        {
            return db.Patients;
        }

        public Patient GetById(int id)
        {
            return db.Patients.Find(id);
        }

        public void Create(Patient patient)
        {
            db.Patients.Add(patient);
        }

        public void Update(Patient patient)
        {
            db.Entry(patient).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Patient patient = db.Patients.Find(id);
            if (patient != null)
                db.Patients.Remove(patient);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
