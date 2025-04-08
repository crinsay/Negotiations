using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Negotiations.Application.Negotiations.Dtos;
using Negotiations.Domain.Entities;
using Negotiations.Domain.Exceptions;
using Negotiations.Domain.Repositories;

namespace Negotiations.Application.Negotiations.Queries.GetAllNegotiationsForProduct;

public class GetAllNegotiationsForProductQueryHandler(ILogger<GetAllNegotiationsForProductQueryHandler> logger,
    IProductsRepository productsRepository,
    IMapper mapper) : IRequestHandler<GetAllNegotiationsForProductQuery, IEnumerable<NegotiationDto>>
{
    public async Task<IEnumerable<NegotiationDto>> Handle(GetAllNegotiationsForProductQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling GetAllNegotiationsForProductQuery for productId: {ProductId}", request.ProductId);
        var product = await productsRepository.GetProductByIdAsync(request.ProductId)
            ?? throw new NotFoundException(nameof(Product), request.ProductId.ToString());

        var negotiations = mapper.Map<IEnumerable<NegotiationDto>>(product.Negotiations);

        return negotiations;

    }
}