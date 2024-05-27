using gRPC.Application.Common;
using gRPC.Domain;
using gRPC.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gRPC.Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, User>
    {
        private readonly IBaseRepository<User> _userRepository;

        public GetUserDetailsQueryHandler(IBaseRepository<User> founderRepository)
        {
            _userRepository = founderRepository;
        }

        public async Task<User> Handle(GetUserDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _userRepository.Select()
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            return entity;
        }
    }
}
