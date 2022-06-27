using AutoMapper;
using System.Linq;
using Voting.Domain.Entities;

namespace Voting.Application.Voters.Queries.GetVotersList
{
    public  class VoterDtoMapperProfile : Profile
    {
        public VoterDtoMapperProfile()
        {
            CreateMap<Voter, VotersDto>()
                .ForMember(dest => dest.HasVoted, opt => opt.MapFrom(src => src.Votes.Any()));
        }
    }
}
