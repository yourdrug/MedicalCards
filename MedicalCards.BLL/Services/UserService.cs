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
using Microsoft.EntityFrameworkCore;

namespace MedicalCards.BLL.Services
{
    public class UserService : IDisposable
    {
        private readonly IUserRepository userRepository;
        private readonly IPatientRepository patientRepository;
        private readonly IDoctorRepository doctorRepository;

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
        public UserService(IUserRepository userRepository, IPatientRepository patientRepository, IDoctorRepository doctorRepository)
        { 
            this.userRepository = userRepository;
            this.patientRepository = patientRepository;
            this.doctorRepository = doctorRepository;
        }

        public async Task<User> Authentificate(string login, string password)
        {
            try
            {
                var user = await userRepository.FindByCredits(login, GetSHA256Hash(password));
                return user;
            }
            catch (InvalidOperationException ex)
            {
                // Пробрасываем исключение дальше
                throw ex;
            }
        }

        public void CancelSignUp(User user)
        {
            userRepository.Delete(user);
        }

        public async Task<User> SignUp(string login, string password, string role)
        {
            if (await userRepository.isUniqueLogin(login))
            {
                User user = new User();
                user.Login = login;
                user.Hash = GetSHA256Hash(password);
                switch (role)
                {
                    case "Admin":
                        user.Role = User.RoleType.Admin;
                        break;
                    case "Patient":
                        user.Role = User.RoleType.Patient;
                        break;
                    case "Doctor":
                        user.Role = User.RoleType.Doctor;
                        break;
                }

                user.Access = User.AccessType.UnderInvestigation;

                User user2 = await userRepository.Create(user);
                userRepository.Save();

                return user2;
            }

            else
            {
                throw new Exception("Incorrect login");
            }

        }


        public async Task<Patient> GetPatientByUser(User user)
        {
            return await patientRepository.GetByIdWithAllDependencies(user.UserId);
        }

        public async Task<Doctor> GetDoctorByUser(User user)
        {
            return await doctorRepository.GetByIdWithAllDependencies(user.UserId);
        }

        public async Task<User> DeleteById(int id)
        {
            return await userRepository.Delete(id);
        }

        public async Task<Array> GetAllUsers()
        {
            return (Array)await userRepository.GetAll();
        }

        public async Task<User> UpdateUser(User user)
        {
            await userRepository.Update(user);
            return user;
        }

        public void Dispose()
        {
            userRepository.Dispose();
        }
    }
}
