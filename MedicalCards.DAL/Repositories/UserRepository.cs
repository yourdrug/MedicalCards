using MedicalCards.DAL.Entities;
using MedicalCards.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppContext context) : base(context)
        {
            
        }

        public async Task<User> FindByCredits(string login, string hash)
        {
            var user = await set.SingleAsync(user => EF.Functions.Collate(user.Login, "SQL_Latin1_General_CP1_CS_AS") == login && user.Hash == hash);
            
            return user;
        }

        public async Task<bool> isUniqueLogin(string login)
        {
            return !await _context.Users.AnyAsync(user => user.Login == login);
        }

    }
}
