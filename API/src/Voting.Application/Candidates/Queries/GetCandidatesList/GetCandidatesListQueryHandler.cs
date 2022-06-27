using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Voting.Persistence;

namespace Voting.Application.Candidates.Queries.GetCandidatesList
{
    internal class GetCandidatesListQueryHandler : IRequestHandler<GetCandidatesListQuery, IEnumerable<CandidatesDto>>
    {
        private readonly VoteDbContext _voteDbContext;
        private readonly IMapper _mapper;

        public GetCandidatesListQueryHandler(VoteDbContext voteDbContext, IMapper mapper)
        {
            _voteDbContext = voteDbContext ?? throw new ArgumentNullException(nameof(voteDbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CandidatesDto>> Handle(GetCandidatesListQuery request, CancellationToken cancellationToken)
        {

            var candidatesEntites = await _voteDbContext.Candidates
                .Include(x => x.Votes)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CandidatesDto>>(candidatesEntites);
        }
    }
}
