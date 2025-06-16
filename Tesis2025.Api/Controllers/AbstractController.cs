using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tesis2025.Application.Common.Interface;

namespace Tesis2025.Api.Controllers
{
    public abstract class AbstractController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
