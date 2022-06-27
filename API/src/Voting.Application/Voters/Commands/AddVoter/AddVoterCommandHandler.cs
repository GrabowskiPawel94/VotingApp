using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Voting.Domain.Entities;
using Voting.Persistence;

namespace Voting.Application.Voters.Commands.AddVoter
{
    internal class AddVoterCommandHandler : IRequestHandler<AddVoterCommand>
    {
        private readonly VoteDbContext _voteDbContext;

        public AddVoterCommandHandler(VoteDbContext voteDbContext)
        {
            _voteDbContext = voteDbContext ?? throw new ArgumentNullException(nameof(voteDbContext));
        }

        public async Task<Unit> Handle(AddVoterCommand request, CancellationToken cancellationToken)
        {
            var voter = new Voter(request.Name);

            await _voteDbContext.AddAsync(voter);

            await _voteDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
