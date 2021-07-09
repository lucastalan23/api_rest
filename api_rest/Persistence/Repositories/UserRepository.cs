using api_rest.Domain.Models;
using api_rest.Domain.Repositories;
using api_rest.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_rest.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {

        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User User)
        {
            await _context.AddAsync(User);
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> FirstOrDefaultAsync(string Login, string password)
        {
            var userTemp = await _context.Users.FirstOrDefaultAsync(x => x.Login == Login);

            if (userTemp == null)
                return userTemp;
            else
                return await _context.Users.FirstOrDefaultAsync(x => x.Password == password);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    
        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }

    }
}
