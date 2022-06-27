using MediatR;
using System.Collections.Generic;

namespace Voting.Application.Voters.Queries.GetVotersList
{
    public class GetVotersListQuery : IRequest<IEnumerable<VotersDto>>
    {
    }
}
