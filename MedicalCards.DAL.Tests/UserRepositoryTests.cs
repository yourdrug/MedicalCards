using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Tests
{
    public class UserRepositoryTests : RepositoryTests<User>
    {
        public UserRepositoryTests() : base(context => new UserRepository(context))
        {
            repository = new UserRepository(_context);
        }
    }
}
