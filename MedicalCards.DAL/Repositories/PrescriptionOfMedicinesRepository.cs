using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Repositories
{
    public class PrescriptionOfMedicinesRepository : Repository<PrescriptionOfMedicines>,IPrescriptionOfMedicinesRepository
    {
        public PrescriptionOfMedicinesRepository(AppContext context) : base(context) 
        {
            
        }

        public async Task<PrescriptionOfMedicines> GetByIdWithAllDependencies(int id)
        {
            var pom =  await set.Include(p => p.Appointment)
                            .Include(p => p.Medicines).SingleAsync(p => p.AppointmentId == id);

            if (pom == null)
            {
                throw new Exception("No pom by this id");
            }

            else
            {
                return pom;
            }
        }


    }
}
