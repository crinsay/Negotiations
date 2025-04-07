using AutoMapper;
using Negotiations.Domain.Entities;

namespace Negotiations.Application.Negotiations.Dtos;

public class NegotiationProfile : Profile
{
    public NegotiationProfile()
    {
        CreateMap<Negotiation, NegotiationDto>();
        CreateMap<NegotiationDto, Negotiation>();
    }
}
