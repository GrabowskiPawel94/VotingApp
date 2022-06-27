using System;

namespace Voting.Domain.Entities
{
    public class Votes : BaseEntity<Guid>
    {
        public Voter Voter { get; set; }
        public Guid VoterId { get; set; }

        public Candidate Candidate { get; set; }
        public Guid CandidateId { get; set; }
    }
}
