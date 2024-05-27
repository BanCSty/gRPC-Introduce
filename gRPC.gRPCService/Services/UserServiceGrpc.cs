using gRPC.Application.Users.Command.CreateUser;
using gRPC.Application.Users.Command.DeleteUser;
using gRPC.Application.Users.Command.UpdateUser;
using gRPC.Application.Users.Queries.GetUserDetails;
using gRPC.Application.Users.Queries.GetUserList;
using Grpc.Core;
using MediatR;

namespace gRPC.gRPCService.Services
{
    public class UserServiceGrpc : UserService.UserServiceBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserServiceGrpc> _logger;

        public UserServiceGrpc(IMediator mediator, ILogger<UserServiceGrpc> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public override async Task<UserList> GetAllUsers(Empty request, ServerCallContext context)
        {
            var users = await _mediator.Send(new GetUserListQuery());
            var response = new UserList();
            response.Users.AddRange(users.Select(user => new User
            {
                Id = user.Id.ToString(),
                Name = user.Name
            }));

            return response;
        }

        public override async Task<User> GetUserDetails(UserRequest request, ServerCallContext context)
        {
            var user = await _mediator.Send(new GetUserDetailsQuery {Id = Guid.Parse(request.Id)});

            return new User { Id = user.Id.ToString(), Name = user.Name };
        }

        public override async Task<Empty> CreateUser(User request, ServerCallContext context)
        {
            var command = new CreateUserCommand
            {
                Name = request.Name
            };

            await _mediator.Send(command);

            return new Empty();
        }

        public override async Task<Empty> DeleteUser(UserRequest request, ServerCallContext context)
        {
            var command = new DeleteUserCommand
            {
                Id = Guid.Parse(request.Id)
            };

            await _mediator.Send(command);

            return new Empty(); 
        }

        public override async Task<Empty> UpdateUser(User request, ServerCallContext context)
        {
            var command = new UpdateUserCommand
            {
                Id = Guid.Parse(request.Id),
                Name = request.Name,
            };

            await _mediator.Send(command);

            return new Empty();
        }
    }
}
