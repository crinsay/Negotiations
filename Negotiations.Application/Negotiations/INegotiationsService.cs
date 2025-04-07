using Negotiations.Application.Negotiations.Dtos;

namespace Negotiations.Application.Negotiations;

public interface INegotiationsService
{
    Task<IEnumerable<NegotiationDto>> GetAllNegotiationsAsync();
}