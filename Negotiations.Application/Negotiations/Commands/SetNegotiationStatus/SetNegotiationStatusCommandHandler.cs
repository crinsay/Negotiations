using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Negotiations.Domain.Constants;
using Negotiations.Domain.Entities;
using Negotiations.Domain.Exceptions;
using Negotiations.Domain.Repositories;

namespace Negotiations.Application.Negotiations.Commands.SetNegotiationStatus;

public class SetNegotiationStatusCommandHandler(ILogger<SetNegotiationStatusCommandHandler> logger,
    IMapper mapper,
    IProductsRepository productsRepository) : IRequestHandler<SetNegotiationStatusCommand>
{
    public async Task Handle(SetNegotiationStatusCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Setting negotiation status for product with id: {ProductId} to {Status}", request.ProductId, request.Status);
        var product = await productsRepository.GetProductByIdAsync(request.ProductId)
            ?? throw new NotFoundException(nameof(Product), request.ProductId.ToString());

        var negotiation = product.Negotiations.LastOrDefault()
            ?? throw new NotFoundException(nameof(Negotiation), request.ProductId.ToString());

        if (!negotiation.Status.Equals(NegotiationStatuses.Pending))
            throw new Exception($"Negotiation already {request.Status.ToLower()}");

        mapper.Map(request, negotiation);

        await productsRepository.SaveChanges();
    }
}
