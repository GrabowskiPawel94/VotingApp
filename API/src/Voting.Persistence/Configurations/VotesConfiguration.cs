using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Voting.Domain.Entities;

namespace Voting.Persistence.Configurations
{
    internal class VotesConfiguration : IEntityTypeConfiguration<Votes>
    {
        public void Configure(EntityTypeBuilder<Votes> builder)
        {
            builder.HasOne(x => x.Voter)
                .WithMany(x => x.Votes)
                .HasForeignKey(x => x.VoterId);

            builder.HasOne(x => x.Candidate)
                .WithMany(x => x.Votes)
                .HasForeignKey(x => x.CandidateId);

            builder.HasIndex(x => new { x.CandidateId, x.VoterId })
                .IsUnique();
        }
    }
}
