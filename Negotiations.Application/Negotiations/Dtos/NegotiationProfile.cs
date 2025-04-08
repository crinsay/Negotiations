using AutoMapper;
using Negotiations.Application.Negotiations.Commands.CreateNegotiation;
using Negotiations.Application.Negotiations.Commands.SetNegotiationStatus;
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
        CreateMap<SetNegotiationStatusCommand, Negotiation>()
                   .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                   .ForMember(dest => dest.DeclineDate, opt => opt.MapFrom(src =>
                       src.Status == NegotiationStatuses.Declined ? DateTime.UtcNow : (DateTime?)null));

    }
}
