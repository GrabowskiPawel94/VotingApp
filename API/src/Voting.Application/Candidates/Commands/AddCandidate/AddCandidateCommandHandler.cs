using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Voting.Domain.Entities;
using Voting.Persistence;

namespace Voting.Application.Candidates.Commands.AddCandidate
{
    internal class AddCandidateCommandHandler : IRequestHandler<AddCandidateCommand>
    {
        private readonly VoteDbContext _voteDbContext;

        public AddCandidateCommandHandler(VoteDbContext voteDbContext)
        {
            _voteDbContext = voteDbContext ?? throw new ArgumentNullException(nameof(voteDbContext));
        }

        public async Task<Unit> Handle(AddCandidateCommand request, CancellationToken cancellationToken)
        {
            var voter = new Candidate(request.Name);

            await _voteDbContext.AddAsync(voter);

            await _voteDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
