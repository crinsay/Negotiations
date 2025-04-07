using AutoMapper;
using Microsoft.Extensions.Logging;
using Negotiations.Application.Negotiations.Dtos;
using Negotiations.Domain.Repositories;

namespace Negotiations.Application.Negotiations;

internal class NegotiationsService(INegotiationsRepository negotiationsRepository, 
    ILogger<NegotiationsService> logger,
    IMapper mapper) : INegotiationsService
{
    public async Task<IEnumerable<NegotiationDto>> GetAllNegotiationsAsync()
    {
        logger.LogInformation("Fetching all negotiation from the repository.");
        var negotiations = await negotiationsRepository.GetAllNegotiationsAsync();
        var negotiationsDtos = mapper.Map<IEnumerable<NegotiationDto>>(negotiations);

        return negotiationsDtos;
    }
}
