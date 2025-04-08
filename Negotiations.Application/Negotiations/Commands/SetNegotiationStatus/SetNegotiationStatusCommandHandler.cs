using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Negotiations.Domain.Constants;
using Negotiations.Domain.Repositories;

namespace Negotiations.Application.Negotiations.Commands.SetNegotiationStatus;

public class SetNegotiationStatusCommandHandler(ILogger<SetNegotiationStatusCommandHandler> logger,
    IMapper mapper,
    IProductsRepository productsRepository) : IRequestHandler<SetNegotiationStatusCommand>
{
    public async Task Handle(SetNegotiationStatusCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Setting negotiation status for product with id: {ProductId} to {Status}", request.ProductId, request.Status);
        var product = await productsRepository.GetProductByIdAsync(request.ProductId);
        if (product is null)
            throw new Exception("Product not found");

        var negotiation = product.Negotiations.LastOrDefault();
        if (negotiation is null)
            throw new Exception("Negotiation not found");

        if (!negotiation.Status.Equals(NegotiationStatuses.Pending))
            throw new Exception($"Negotiation already {request.Status.ToLower()}");

        mapper.Map(request, negotiation);

        await productsRepository.SaveChanges();
    }
}
