using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Services.UserService
{
    public interface IUserService
    {
        Task<User> GetUser(Guid userId, CancellationToken cancellationToken);
    }
}
