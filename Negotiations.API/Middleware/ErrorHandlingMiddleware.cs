
using Negotiations.Domain.Exceptions;

namespace Negotiations.API.Middleware;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException notFound)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync(notFound.Message);

            logger.LogWarning(notFound.Message);
        }
        catch (NegotiationAlreadyFinalizedException negotiationAlreadyFinalized)
        {
            context.Response.StatusCode = 409;
            await context.Response.WriteAsync(negotiationAlreadyFinalized.Message);

            logger.LogWarning(negotiationAlreadyFinalized.Message);
        }
        catch (NegotiationDurationExceededException negotiationDurationExceeded)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync(negotiationDurationExceeded.Message);

            logger.LogWarning(negotiationDurationExceeded.Message);
        }
        catch (NegotiationLimitReachedException negotiationLimitReached)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync(negotiationLimitReached.Message);

            logger.LogWarning(negotiationLimitReached.Message);
        }
        catch (NegotiationBlockedStatusException negotiationNotDeclined)
        {
            context.Response.StatusCode = 409;
            await context.Response.WriteAsync(negotiationNotDeclined.Message);

            logger.LogWarning(negotiationNotDeclined.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);

            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Something went wrong");
        }
    }
}
