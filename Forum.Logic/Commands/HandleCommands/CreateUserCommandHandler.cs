using Forum.Domain.Entities;
using Forum.Infrastructure.Repository.IRepository;
using Forum.Logic.Commands.CreateCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Logic.Commands.HandleCommands
{
    public class CreateUserCommandHandler(IRepository<User> _userRepository) : IRequestHandler<CreateUserCommand, User>
    {
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.FirstName, request.LastName, request.UserName, request.Password, request.Email);

            if (await _userRepository.AddUser(user, cancellationToken))
            {
                return user;
            }

            throw new Exception("Could not create User");

        }
    }
}
