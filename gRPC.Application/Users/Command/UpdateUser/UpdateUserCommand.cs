using MediatR;

namespace gRPC.Application.Users.Command.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
