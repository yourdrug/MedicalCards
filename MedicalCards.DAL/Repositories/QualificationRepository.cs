﻿using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Repositories
{
    public class QualificationRepository : Repository<Qualification>,IQualificationRepository
    {
        public QualificationRepository(AppContext context) : base(context)
        {
            
        }
    }
}
