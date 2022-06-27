using System;
using System.Collections.Generic;

namespace Voting.Domain.Entities
{
    public class Voter : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public ICollection<Votes> Votes { get; set; }

        protected Voter()
        {
            Votes = new List<Votes>();
        }

        public Voter(string name)
        {
            Name = name;
            Votes = new List<Votes>();
        }
    }
}
