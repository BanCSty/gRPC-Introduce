using gRPC.Domain;
using MediatR;

namespace gRPC.Application.Users.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<List<User>>
    {

    }
}
