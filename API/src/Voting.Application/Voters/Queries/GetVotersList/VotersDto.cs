using System;

namespace Voting.Application.Voters.Queries.GetVotersList
{
    public class VotersDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool HasVoted { get; set; }
    }
}
