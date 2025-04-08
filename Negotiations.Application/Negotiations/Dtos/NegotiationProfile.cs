using AutoMapper;
using Negotiations.Application.Negotiations.Commands;
using Negotiations.Domain.Constants;
using Negotiations.Domain.Entities;

namespace Negotiations.Application.Negotiations.Dtos;

public class NegotiationProfile : Profile
{
    public NegotiationProfile()
    {
        CreateMap<Negotiation, NegotiationDto>();
        CreateMap<NegotiationDto, Negotiation>();
        CreateMap<CreateNegotiationCommand, Negotiation>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => NegotiationStatuses.Pending));
    }
}
