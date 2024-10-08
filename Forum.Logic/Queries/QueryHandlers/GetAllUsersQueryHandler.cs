using Forum.Domain.Entities;
using Forum.Infrastructure.Repository.IRepository;
using Forum.Logic.Queries.Querys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Logic.Queries.QueryHandlers
{
    public class GetAllUsersQueryHandler(IRepository<User> _userRepository) : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUsers(cancellationToken);
        }
    }
}
