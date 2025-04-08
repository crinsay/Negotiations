namespace Negotiations.Domain.Exceptions;

public class NegotiationBlockedStatusException(int productId)
    : Exception($"Product with id {productId} can't be currently negotiated due to its status")
{ }
