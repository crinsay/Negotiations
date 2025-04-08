using Negotiations.Domain.Entities;


namespace Negotiations.Domain.Repositories;

public interface INegotiationsRepository
{
    Task<int> CreateNegotiationAsync(Negotiation negotiation);
}
