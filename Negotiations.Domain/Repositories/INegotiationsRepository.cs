using Negotiations.Domain.Entities;


namespace Negotiations.Domain.Repositories;

public interface INegotiationsRepository
{
    Task<IEnumerable<Negotiation>> GetAllNegotiationsAsync();
}
