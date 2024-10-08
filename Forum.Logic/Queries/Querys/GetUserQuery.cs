using Forum.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Logic.Queries.Querys
{
    public class GetUserQuery : IRequest<User>
    {
        public Guid UserId { get; set; }
    }
}
