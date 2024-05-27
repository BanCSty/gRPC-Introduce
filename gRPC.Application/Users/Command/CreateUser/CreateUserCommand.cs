using MediatR;


namespace gRPC.Application.Users.Command.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string Name { get; set;}
    }
}
