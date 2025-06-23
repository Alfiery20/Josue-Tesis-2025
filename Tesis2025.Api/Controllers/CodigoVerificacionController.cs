using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tesis2025.Application.Autenticacion.Command.IniciarSesion;
using Tesis2025.Application.Autenticacion.Command.Registrar;
using Tesis2025.Application.CodigoVerificacion.Command.EnviarCodigo;
using Tesis2025.Application.CodigoVerificacion.Command.ValidarCodigo;

namespace Tesis2025.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CodigoVerificacionController : AbstractController
    {
        [HttpPost]
        [Route("registrarCodigo")]
        [ProducesResponseType(typeof(EnviarCodigoCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> IniciarSesion(EnviarCodigoCommand command)
        {
            var response = await Mediator.Send(command);
            if (response.Codigo != "OK")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("validarCodigo")]
        [ProducesResponseType(typeof(ValidarCodigoCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Registrar(ValidarCodigoCommand command)
        {
            var response = await Mediator.Send(command);
            if (response.Codigo != "OK")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
