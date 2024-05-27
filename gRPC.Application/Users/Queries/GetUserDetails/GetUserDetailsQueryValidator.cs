using FluentValidation;

namespace gRPC.Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryValidator : AbstractValidator<GetUserDetailsQuery>
    {
        public GetUserDetailsQueryValidator()
        {
            RuleFor(getUserDetailsQuery => getUserDetailsQuery.Id).NotEqual(Guid.Empty);
        }
    }
}
