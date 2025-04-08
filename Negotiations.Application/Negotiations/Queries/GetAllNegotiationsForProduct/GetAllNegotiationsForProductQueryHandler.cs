using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Negotiations.Application.Negotiations.Dtos;
using Negotiations.Domain.Repositories;

namespace Negotiations.Application.Negotiations.Queries.GetAllNegotiationsForProduct;

public class GetAllNegotiationsForProductQueryHandler(ILogger<GetAllNegotiationsForProductQueryHandler> logger,
    IProductsRepository productsRepository,
    IMapper mapper) : IRequestHandler<GetAllNegotiationsForProductQuery, IEnumerable<NegotiationDto>>
{
    public async Task<IEnumerable<NegotiationDto>> Handle(GetAllNegotiationsForProductQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling GetAllNegotiationsForProductQuery for productId: {ProductId}", request.ProductId);
        var product = await productsRepository.GetProductByIdAsync(request.ProductId);

        if (product == null)
            throw new Exception("restaurant not found");

        var negotiations = mapper.Map<IEnumerable<NegotiationDto>>(product.Negotiations);

        return negotiations;

    }
}