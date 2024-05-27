using gRPC.Domain.Interfaces;
using gRPC.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using gRPC.Application.Common;

namespace gRPC.Application.Users.Command.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IBaseRepository<User> _userRepository;

        public UpdateUserCommandHandler(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Select().FirstOrDefaultAsync(user => user.Id == request.Id, cancellationToken);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            user.Name = request.Name;

            await _userRepository.Update(user, cancellationToken);

            return Unit.Value;
        }
    }
}
