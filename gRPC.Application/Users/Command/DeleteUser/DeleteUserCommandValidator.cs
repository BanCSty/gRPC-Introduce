using FluentValidation;

namespace gRPC.Application.Users.Command.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(deleteUserCommand => deleteUserCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
