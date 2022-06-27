using FluentValidation;

namespace Voting.Application.Candidates.Commands.AddCandidate
{
    public class AddCandidateCommandValidator : AbstractValidator<AddCandidateCommand>
    {
        public AddCandidateCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
