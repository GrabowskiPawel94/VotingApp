using FluentValidation;

namespace Voting.Application.Voters.Commands.AddVoter
{
    public class AddVoterCommandValidator : AbstractValidator<AddVoterCommand>
    {
        public AddVoterCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
