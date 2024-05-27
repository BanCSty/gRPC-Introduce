using FluentValidation;

namespace gRPC.Application.Users.Command.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(createUserCommand => createUserCommand.Name).NotEmpty().MaximumLength(30);
        }
    }
}
