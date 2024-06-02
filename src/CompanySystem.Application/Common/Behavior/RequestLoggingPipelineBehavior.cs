using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace CompanySystem.Application.Common.Behavior;

public sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : IErrorOr
{
    private readonly ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> _logger;
    public RequestLoggingPipelineBehavior(ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        string requestName = typeof(TRequest).Name;
        _logger.LogInformation("Processing request {RequestName}", requestName);

        var response = await next();

        if (response.IsError)
        {
            using (LogContext.PushProperty("Error", response.Errors))
            {
                _logger.LogError("Completed request {RequestName} failed with error", requestName);
            }
        }
        else
        {
            _logger.LogInformation("Completed request {RequestName} processed successfully", requestName);
        }

        return response;
    }
}
