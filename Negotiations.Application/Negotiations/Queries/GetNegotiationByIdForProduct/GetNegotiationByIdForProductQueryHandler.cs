using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Negotiations.Application.Negotiations.Dtos;
using Negotiations.Application.Negotiations.Queries.GetAllNegotiationsForProduct;
using Negotiations.Domain.Entities;
using Negotiations.Domain.Exceptions;
using Negotiations.Domain.Repositories;

namespace Negotiations.Application.Negotiations.Queries.GetNegotiationByIdForProduct;

public class GetNegotiationByIdForProductQueryHandler(ILogger<GetAllNegotiationsForProductQueryHandler> logger,
    IProductsRepository productsRepository,
    IMapper mapper) : IRequestHandler<GetNegotiationByIdForProductQuery, NegotiationDto>
{
    public async Task<NegotiationDto> Handle(GetNegotiationByIdForProductQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling GetNegotiationByIdForProductQuery for productId: {ProductId} and negotiationId: {NegotiationId}", request.ProductId, request.NegotiationId);
        var product = await productsRepository.GetProductByIdAsync(request.ProductId)
            ?? throw new NotFoundException(nameof(Product), request.ProductId.ToString());

        var negotiation = product.Negotiations.FirstOrDefault(n => n.Id == request.NegotiationId)
            ?? throw new NotFoundException(nameof(Negotiation), request.NegotiationId.ToString());

        var negotiationDto = mapper.Map<NegotiationDto>(negotiation);

        return negotiationDto;
    }
}
