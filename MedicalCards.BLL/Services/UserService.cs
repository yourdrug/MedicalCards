using MedicalCards.DAL;
using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories;
using MedicalCards.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.BLL.Services
{
    public class UserService : IDisposable
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        { 
            this.userRepository = userRepository;
        }

        public async Task<User> Authentificate(string login, string password)
        {
            string hash = string.Empty;
            //hash = password.Hash();

            var user = await userRepository.FindByCredits(login, hash);

            return user;
        }

        public void Dispose()
        {
            userRepository.Dispose();
        }
    }
}
