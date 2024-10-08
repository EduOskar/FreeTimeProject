using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        public Task<User> GetUser(Guid id, CancellationToken cancellationToken);

        public Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken);

        public Task<bool> AddUser(User user, CancellationToken cancellationToken);

        public Task<bool> DeleteUser(Guid userId, CancellationToken cancellationToken);

        Task<bool> Save();
    }
}
