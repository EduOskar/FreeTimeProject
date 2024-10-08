using Forum.Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Services.UserService
{
    public class UserService(IRepository<Domain.Entities.User> userRepository) : IUserService
    {
        public async Task<Domain.Entities.User> GetUser(Guid userId, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUser(userId, cancellationToken);

            if (user is null) { throw new Exception($"User with id {user!.Id} was not found"); }

            return user;
        }
    }
}
