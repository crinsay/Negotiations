using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Negotiations.Domain.Entities;
using Negotiations.Domain.Repositories;

namespace Negotiations.Application.Negotiations.Commands.CreateNegotiation;

public class CreateNegotiationCommandHandler(ILogger<CreateNegotiationCommandHandler> logger,
    IProductsRepository productsRepository,
    INegotiationsRepository negotiationsRepository,
    IMapper mapper) : IRequestHandler<CreateNegotiationCommand, int>
{
    public async Task<int> Handle(CreateNegotiationCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new negotiation : {@NegotiationRequest}", request);
        var product = await productsRepository.GetProductByIdAsync(request.ProductId);

        if (product == null)
        {
            logger.LogWarning("Product with id {ProductId} not found", request.ProductId);
            throw new Exception("Product not found");
        }

        var negotiation = mapper.Map<Negotiation>(request);

        return await negotiationsRepository.CreateNegotiationAsync(negotiation);
    }
}
