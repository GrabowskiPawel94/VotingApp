using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Voting.Domain.Entities;

namespace Voting.Persistence.Configurations
{
    internal class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}
