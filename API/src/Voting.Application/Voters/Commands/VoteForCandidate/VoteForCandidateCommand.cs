using MediatR;
using System;

namespace Voting.Application.Voters.Commands.VoteForCandidate
{
    public class VoteForCandidateCommand : IRequest
    {
        public Guid VoterId { get; init; }
        public Guid CandidateId { get; init; }

        public VoteForCandidateCommand(Guid voterId, Guid candidateId)
        {
            VoterId = voterId;
            CandidateId = candidateId;
        }
    }
}
