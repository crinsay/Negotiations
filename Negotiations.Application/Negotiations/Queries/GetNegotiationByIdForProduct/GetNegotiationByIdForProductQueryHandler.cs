using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Negotiations.Application.Negotiations.Dtos;
using Negotiations.Application.Negotiations.Queries.GetAllNegotiationsForProduct;
using Negotiations.Domain.Repositories;

namespace Negotiations.Application.Negotiations.Queries.GetNegotiationByIdForProduct;

public class GetNegotiationByIdForProductQueryHandler(ILogger<GetAllNegotiationsForProductQueryHandler> logger,
    IProductsRepository productsRepository,
    IMapper mapper) : IRequestHandler<GetNegotiationByIdForProductQuery, NegotiationDto>
{
    public async Task<NegotiationDto> Handle(GetNegotiationByIdForProductQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling GetNegotiationByIdForProductQuery for productId: {ProductId} and negotiationId: {NegotiationId}", request.ProductId, request.NegotiationId);
        var product = await productsRepository.GetProductByIdAsync(request.ProductId);

        if (product == null)
            throw new Exception("restaurant not found");

        var negotiation = product.Negotiations.FirstOrDefault(n => n.Id == request.NegotiationId);
        if (negotiation == null)
            throw new Exception("negotiation not found");

        var negotiationDto = mapper.Map<NegotiationDto>(negotiation);

        return negotiationDto;
    }
}
