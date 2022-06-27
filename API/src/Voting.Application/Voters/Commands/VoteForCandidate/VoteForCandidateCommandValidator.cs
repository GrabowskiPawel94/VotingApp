using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Voting.Persistence;

namespace Voting.Application.Voters.Commands.VoteForCandidate
{
    public class VoteForCandidateCommandValidator : AbstractValidator<VoteForCandidateCommand>
    {
        private readonly VoteDbContext _voteDbContext;

        public VoteForCandidateCommandValidator(VoteDbContext voteDbContext)
        {
            _voteDbContext = voteDbContext ?? throw new ArgumentNullException(nameof(voteDbContext));

            RuleFor(x => x.VoterId).MustAsync(VoterExists)
                .WithMessage("Voter does not exist")
                .DependentRules(() =>
                {
                    RuleFor(x => x.VoterId).MustAsync(DidNotVote)
                    .WithMessage("Voter already voted for the candidate");
                });

            RuleFor(x => x.CandidateId).MustAsync(CandidateExists)
                .WithMessage("Candidate does not exist");
        }

        private async Task<bool>VoterExists(VoteForCandidateCommand request, Guid voterId, CancellationToken _)
        {
            return await _voteDbContext.Voters
                .AnyAsync(x => x.Id == voterId);
        }

        private async Task<bool> DidNotVote(VoteForCandidateCommand request, Guid voterId, CancellationToken _)
        {
            return !await _voteDbContext.Voters
                .Include(x => x.Votes)
                .AnyAsync(x => x.Votes.Any());
        }

        private async Task<bool> CandidateExists(VoteForCandidateCommand request, Guid candidateId, CancellationToken _)
        {
            return await _voteDbContext.Candidates
                .AnyAsync(x => x.Id == candidateId);
        }
    }
}
