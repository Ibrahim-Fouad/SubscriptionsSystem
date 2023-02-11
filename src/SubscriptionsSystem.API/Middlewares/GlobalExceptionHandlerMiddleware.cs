using SubscriptionsSystem.Application.DTOs;

namespace SubscriptionsSystem.API.Middlewares;

public class GlobalExceptionHandlerMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unexpected error happened, error message: {e.Message}", e.Message);
            var apiResult = new ErrorResultDto(StatusCodes.Status500InternalServerError, e.Message);
#if DEBUG
            apiResult = new(StatusCodes.Status500InternalServerError, e.Message, e.StackTrace);
#endif
            context.Response.StatusCode = apiResult.StatusCode;
            await context.Response.WriteAsJsonAsync(apiResult);
        }
    }
}