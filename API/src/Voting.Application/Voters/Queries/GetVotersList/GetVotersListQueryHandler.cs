using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Voting.Persistence;

namespace Voting.Application.Voters.Queries.GetVotersList
{
    internal class GetVotersListQueryHandler : IRequestHandler<GetVotersListQuery, IEnumerable<VotersDto>>
    {
        private readonly VoteDbContext _voteDbContext;
        private readonly IMapper _mapper;

        public GetVotersListQueryHandler(VoteDbContext voteDbContext, IMapper mapper)
        {
            _voteDbContext = voteDbContext ?? throw new ArgumentNullException(nameof(voteDbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<VotersDto>> Handle(GetVotersListQuery request, CancellationToken cancellationToken)
        {
            var votersEntites = await _voteDbContext.Voters
                .ToListAsync();

            return _mapper.Map<IEnumerable<VotersDto>>(votersEntites);
        }
    }
}
