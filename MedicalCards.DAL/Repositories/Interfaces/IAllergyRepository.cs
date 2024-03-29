﻿using MedicalCards.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Repositories.Interfaces
{
    public interface IAllergyRepository:IRepository<Allergy>
    {
        public Task<List<Allergy>> GetAllergiesByPatient(int id);
    }
}
