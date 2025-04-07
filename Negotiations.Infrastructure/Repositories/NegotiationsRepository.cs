using Microsoft.EntityFrameworkCore;
using Negotiations.Domain.Entities;
using Negotiations.Domain.Repositories;
using Negotiations.Infrastructure.Persistence;

namespace Negotiations.Infrastructure.Repositories;

internal class NegotiationsRepository(NegotiationsDbContext dbContext) : INegotiationsRepository
{
    public async Task<IEnumerable<Negotiation>> GetAllNegotiationsAsync()
    {
        var negotiations = await dbContext.Negotiations.ToListAsync();
        return negotiations;
    }
}
