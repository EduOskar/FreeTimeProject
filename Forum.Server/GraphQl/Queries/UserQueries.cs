using Forum.Domain.Entities;
using Forum.Logic.Queries.Querys;
using Forum.Server.GraphQl.Types;
using Forum.Server.Mapper;
using MediatR;

namespace Forum.Server.GraphQl.Queries
{
    public class UserQueries([Service] ILogger<UserQueries> logger) : BaseQuery(logger)
    {
        public async Task<UserType> GetUser([Service] IMediator mediator, Guid userId, CancellationToken cancellationToken)
        {
            var user = await mediator.Send(new GetUserQuery() { UserId = userId}, cancellationToken);

            if (user != null)
            {
                return user.ToUserType();
            }

            return null!;
        }
    }
}
