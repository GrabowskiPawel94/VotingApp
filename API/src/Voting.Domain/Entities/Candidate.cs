using System;
using System.Collections.Generic;

namespace Voting.Domain.Entities
{
    public class Candidate : BaseEntity<Guid>
    {
        public string Name { get; private set; }
        public ICollection<Votes> Votes { get; private set; }

        public Candidate(string name)
        {
            Name = name;
            Votes = new List<Votes>();
        }

        protected Candidate()
        {
            Votes = new List<Votes>();
        }
    }
}
