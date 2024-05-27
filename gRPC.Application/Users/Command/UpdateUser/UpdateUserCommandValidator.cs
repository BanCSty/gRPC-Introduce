using FluentValidation;

namespace gRPC.Application.Users.Command.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(updateUserCommand => updateUserCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateUserCommand => updateUserCommand.Name).NotEmpty().MaximumLength(30);
        }
    }
}
