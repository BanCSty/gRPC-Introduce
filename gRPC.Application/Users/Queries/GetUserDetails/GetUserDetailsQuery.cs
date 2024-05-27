using gRPC.Domain;
using MediatR;

namespace gRPC.Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<User>
    {
        public Guid Id { get; set; }
    }
}
