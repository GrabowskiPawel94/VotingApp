using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Voting.Persistence
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddVotingDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VoteDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("VotingDb")));

            return services;
        }
    }
}
