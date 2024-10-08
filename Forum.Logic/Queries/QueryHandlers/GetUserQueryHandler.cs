using Forum.Domain.Entities;
using Forum.Infrastructure.Services.UserService;
using Forum.Logic.Queries.Querys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Logic.Queries.QueryHandlers
{
    public class GetUserQueryHandler(IUserService userService) : IRequestHandler<GetUserQuery, User>
    {
        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await userService.GetUser(request.UserId, cancellationToken);
        }
    }
}
