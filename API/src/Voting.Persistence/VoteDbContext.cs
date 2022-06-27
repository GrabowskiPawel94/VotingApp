using Microsoft.EntityFrameworkCore;
using Voting.Domain.Entities;

namespace Voting.Persistence
{
    public class VoteDbContext : DbContext
    {
        public VoteDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Voter> Voters { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Votes> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VoteDbContext).Assembly);
        }
    }
}
