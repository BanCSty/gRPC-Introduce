using gRPC.Domain;
using gRPC.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gRPC.Application.Users.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<User>>
    {
        private readonly IBaseRepository<User> _userRepository;

        public GetUserListQueryHandler(IBaseRepository<User> founderRepository)
        {
            _userRepository = founderRepository;
        }

        public async Task<List<User>> Handle(GetUserListQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _userRepository.Select()
                .AsNoTracking()
                .ToListAsync(cancellationToken);


            return entity;
        }
    }
}
