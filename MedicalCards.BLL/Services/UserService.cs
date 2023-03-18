using MedicalCards.DAL;
using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories;
using MedicalCards.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MedicalCards.BLL.Services
{
    public class UserService : IDisposable
    {
        private readonly IUserRepository userRepository;

        private string GetSHA256Hash(string password)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public UserService(IUserRepository userRepository)
        { 
            this.userRepository = userRepository;
        }

        public async Task<User> Authentificate(string login, string password)
        {
            var user = await userRepository.FindByCredits(login, GetSHA256Hash(password));
            return user;
        }

        public void Dispose()
        {
            userRepository.Dispose();
        }
    }
}
