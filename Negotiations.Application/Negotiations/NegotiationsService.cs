using Microsoft.Extensions.Logging;
using Negotiations.Domain.Entities;
using Negotiations.Domain.Repositories;

namespace Negotiations.Application.Negotiations;

internal class NegotiationsService(INegotiationsRepository negotiationsRepository, ILogger<NegotiationsService> logger) : INegotiationsService
{
    public async Task<IEnumerable<Negotiation>> GetAllNegotiationsAsync()
    {
        logger.LogInformation("Fetching all negotiation from the repository.");
        var negotiations = await negotiationsRepository.GetAllNegotiationsAsync();
        return negotiations;
    }
}
