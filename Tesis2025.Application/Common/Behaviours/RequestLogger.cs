using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Tesis2025.Application.Common.Interface;

namespace Tesis2025.Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;

        public RequestLogger(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            //_logger.LogInformation("Procesando request {0} de {1}", typeof(TRequest).Name, _currentUser.Identifier);
            _logger.LogInformation("Procesando request {0} de {1}", typeof(TRequest).Name, "");

            return Task.CompletedTask;
        }
    }
}
