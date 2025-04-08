using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Negotiations.Domain.Constants;
using Negotiations.Domain.Entities;
using Negotiations.Domain.Exceptions;
using Negotiations.Domain.Repositories;
using System.Collections.Generic;

namespace Negotiations.Application.Negotiations.Commands.CreateNegotiation;

public class CreateNegotiationCommandHandler(ILogger<CreateNegotiationCommandHandler> logger,
    IProductsRepository productsRepository,
    INegotiationsRepository negotiationsRepository,
    IMapper mapper) : IRequestHandler<CreateNegotiationCommand, int>
{
    public async Task<int> Handle(CreateNegotiationCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new negotiation : {@NegotiationRequest}", request);
        var product = await productsRepository.GetProductByIdAsync(request.ProductId)
            ?? throw new NotFoundException(nameof(Product), request.ProductId.ToString());


        //Product can be negotiated if:
        // - negotiation attemts are less than maximum negotiation attempts
        if (product.Negotiations.Count >= NegotiationsLimits.MaxNegotiationsLimit)
            throw new NegotiationLimitReachedException(product.Id);

        var lastNegotiation = product.Negotiations.LastOrDefault();

        // - last negotiation is null or if it was declined in less than maximum negotiation duration time
        if (lastNegotiation != null && (!lastNegotiation!.Status.Equals(NegotiationStatuses.Declined)))
            throw new NegotiationBlockedStatusException(product.Id);

        if (lastNegotiation?
            .DeclineDate?
            .AddDays(NegotiationsLimits.MaxNegotiationDurationInDays) < DateTime.Today)
        {
            logger.LogWarning("Product with id {ProductId} has reached the maximum negotiation duration", request.ProductId);

            lastNegotiation.Status = NegotiationStatuses.Cancelled;
            await productsRepository.SaveChanges();

            throw new NegotiationDurationExceededException(product.Id);
        }

        var negotiation = mapper.Map<Negotiation>(request);

        return await negotiationsRepository.CreateNegotiationAsync(negotiation);
    }
}
