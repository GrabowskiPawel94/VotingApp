using AutoMapper;
using System.Linq;
using Voting.Domain.Entities;

namespace Voting.Application.Candidates.Queries.GetCandidatesList
{
    internal class CandidatesDtoMapperProfile : Profile
    {
        public CandidatesDtoMapperProfile()
        {
            CreateMap<Candidate, CandidatesDto>()
                .ForMember(dest => dest.Votes, opt => opt.MapFrom(src => src.Votes.Count()));
        }
    }
}
