using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tesis2025.Application.Autenticacion.Command.IniciarSesion;
using Tesis2025.Application.Autenticacion.Command.Registrar;

namespace Tesis2025.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AutenticacionController : AbstractController
    {
        [HttpPost]
        [Route("iniciarSesion")]
        [ProducesResponseType(typeof(IniciarSesionCommandDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IniciarSesion(IniciarSesionCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        [Route("registrar")]
        [ProducesResponseType(typeof(RegistrarCommandDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Registrar(RegistrarCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
