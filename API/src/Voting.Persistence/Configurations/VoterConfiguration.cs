using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Voting.Domain.Entities;

namespace Voting.Persistence.Configurations
{
    internal class VoterConfiguration : IEntityTypeConfiguration<Voter>
    {
        public void Configure(EntityTypeBuilder<Voter> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}
