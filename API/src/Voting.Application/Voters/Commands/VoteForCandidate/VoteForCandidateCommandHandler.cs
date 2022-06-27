using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Voting.Domain.Entities;
using Voting.Persistence;

namespace Voting.Application.Voters.Commands.VoteForCandidate
{
    internal class VoteForCandidateCommandHandler : IRequestHandler<VoteForCandidateCommand>
    {
        private readonly VoteDbContext _voteDbContext;

        public VoteForCandidateCommandHandler(VoteDbContext voteDbContext)
        {
            _voteDbContext = voteDbContext ?? throw new ArgumentNullException(nameof(voteDbContext));
        }

        public async Task<Unit> Handle(VoteForCandidateCommand request, CancellationToken cancellationToken)
        {
            var vote = new Votes
            {
                VoterId = request.VoterId,
                CandidateId = request.CandidateId
            };

            await _voteDbContext.Votes.AddAsync(vote);
            await _voteDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
