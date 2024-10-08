using Forum.Domain.Entities;
using Forum.Infrastructure.Data;
using Forum.Infrastructure.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddUser(User user, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(user);

            return await Save();
        }

        public async Task<bool> DeleteUser(Guid userId, CancellationToken cancellationToken)
        {
            var userToDelete = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (userToDelete != null)
            {
                _dbContext.Remove(userToDelete);

                return await Save();
            }

            throw new Exception("Could not delete users");
        }

        public async Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken)
        {
            var users = await _dbContext.Users.ToListAsync();

            if (users is not null)
            {
                return users;
            }

            throw new Exception("Could not get list of users");
        }

        public async Task<User> GetUser(Guid ids, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == ids);

            if (user != null)
            {
                return user;
            }

            throw new Exception("No user with that Guid exist");
        }

        public async Task<bool> Save()
        {
            var save = await _dbContext.SaveChangesAsync();

            return save > 0;
        }
    }
}
