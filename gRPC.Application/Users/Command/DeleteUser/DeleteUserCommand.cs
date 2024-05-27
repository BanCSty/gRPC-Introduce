using MediatR;

namespace gRPC.Application.Users.Command.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
