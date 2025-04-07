using Negotiations.Domain.Entities;

namespace Negotiations.Application.Negotiations;

public interface INegotiationsService
{
    Task<IEnumerable<Negotiation>> GetAllNegotiationsAsync();
}