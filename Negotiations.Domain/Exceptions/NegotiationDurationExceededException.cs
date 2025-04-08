namespace Negotiations.Domain.Exceptions;

public class NegotiationDurationExceededException(int productId)
    : Exception($"Product with id {productId} has reached the maximum negotiation duration")
{ }
