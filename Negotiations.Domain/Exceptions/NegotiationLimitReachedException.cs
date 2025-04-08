namespace Negotiations.Domain.Exceptions;

public class NegotiationLimitReachedException(int productId)
    : Exception($"Product with id {productId} has reached the maximum number of negotiations")
{ 

}

