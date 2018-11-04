﻿using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Infrastructure
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
            _timer = new Stopwatch();
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next?.Invoke();

            _timer.Stop();

            if (_timer.ElapsedMilliseconds > 500)
            {
                var name = typeof(TRequest).Name;

                _logger.LogWarning("Long Running Request: {Name} {ElapsedMilliseconds}ms {@Request}", name, _timer.ElapsedMilliseconds, request);
            }

            return response;
        }
    }
}
