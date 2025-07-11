using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tesis2025.Application.CodigoVerificacion.Command.EnviarCodigo;
using Tesis2025.Application.CodigoVerificacion.Command.ValidarCodigo;
using Tesis2025.Application.Mascota.Command.RegistrarMascota;
using Tesis2025.Application.Mascota.Command.RegistrarMascotaPerdida;
using Tesis2025.Application.Mascota.Query.ObtenerMascota;
using Tesis2025.Application.Mascota.Query.ObtenerMascotaPerdida;

namespace Tesis2025.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class MascotaController : AbstractController
    {
        [HttpPost]
        [Route("registrarMascota")]
        [ProducesResponseType(typeof(RegistrarMascotaCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> RegistrarMascota(RegistrarMascotaCommand command)
        {
            var response = await Mediator.Send(command);
            if (response.Codigo != "OK")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("registrarMascotaPerdida")]
        [ProducesResponseType(typeof(RegistrarMascotaPerdidaCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> RegistrarMascotaPerdida(RegistrarMascotaPerdidaCommand command)
        {
            var response = await Mediator.Send(command);
            if (response.Codigo != "OK")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerMascota/{idUsuario?}")]
        [ProducesResponseType(typeof(ObtenerMascotaQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerMascota(int idUsuario)
        {
            var response = await Mediator.Send(new ObtenerMascotaQuery()
            {
                IdUsuario = idUsuario
            });
            if (response.Count() == 0)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerMascotaPerdida/{idUsuario?}")]
        [ProducesResponseType(typeof(ObtenerMascotaQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerMascotaPerdida(int idUsuario)
        {
            var response = await Mediator.Send(new ObtenerMascotaPerdidaQuery()
            {
                IdUsuario = idUsuario
            });
            if (response.Count() == 0)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
