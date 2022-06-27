using MediatR;

namespace Voting.Application.Voters.Commands.AddVoter
{
    public class AddVoterCommand : IRequest
    {
        public string Name { get; init; }
        
        public AddVoterCommand(string name)
        {
            Name = name;
        }
    }
}
