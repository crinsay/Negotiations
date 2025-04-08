namespace Negotiations.Domain.Exceptions;

public class NegotiationAlreadyFinalizedException(string status)
  : Exception($"Negotiation already {status.ToLower()}")
{ 

}
