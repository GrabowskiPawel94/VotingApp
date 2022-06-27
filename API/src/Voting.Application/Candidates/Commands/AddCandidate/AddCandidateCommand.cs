using MediatR;

namespace Voting.Application.Candidates.Commands.AddCandidate
{
    public class AddCandidateCommand : IRequest
    {
        public string Name { get; init; }
        
        public AddCandidateCommand(string name)
        {
            Name = name;
        }
    }
}
