using System;

namespace Voting.Application.Candidates.Queries.GetCandidatesList
{
    public  class CandidatesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Votes { get; set; }
    }
}