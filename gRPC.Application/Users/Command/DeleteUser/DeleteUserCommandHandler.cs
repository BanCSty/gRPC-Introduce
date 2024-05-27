using gRPC.Application.Common;
using gRPC.Domain;
using gRPC.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gRPC.Application.Users.Command.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IBaseRepository<User> _userRepository;

        public DeleteUserCommandHandler(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Select().FirstOrDefaultAsync(x => x.Id == request.Id);

            if (user == null) 
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            await _userRepository.Delete(user,cancellationToken);

            return Unit.Value;
        }
    }
}
