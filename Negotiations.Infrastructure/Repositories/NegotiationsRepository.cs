using Negotiations.Domain.Entities;
using Negotiations.Domain.Repositories;
using Negotiations.Infrastructure.Persistence;

namespace Negotiations.Infrastructure.Repositories;

internal class NegotiationsRepository(NegotiationsDbContext dbContext) : INegotiationsRepository
{
    public async Task<int> CreateNegotiationAsync(Negotiation negotiation)
    {
        dbContext.Negotiations.Add(negotiation);
        await dbContext.SaveChangesAsync();
        return negotiation.Id;
    }
}
