﻿using MedicalCards.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Repositories.Interfaces
{
    public interface IFeaturesRepository:IRepository<Features>
    {
        public Task<Features> GetFeaturesByPatient(int id);

        public Task<bool> isUniqueFeatures(int id);

    }
}
