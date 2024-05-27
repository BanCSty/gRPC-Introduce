using gRPC.Domain;
using gRPC.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gRPC.Application.Users.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IBaseRepository<User> _userRepository;

        public CreateUserCommandHandler(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;   
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userRepository.Select().FirstOrDefaultAsync(user => user.Name == request.Name, cancellationToken);

            if (userExists != null)
            {
                throw new ArgumentException($"Username: {request.Name} already used");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
            };

            await _userRepository.Create(user, cancellationToken);

            return Unit.Value;
        }
    }
}
