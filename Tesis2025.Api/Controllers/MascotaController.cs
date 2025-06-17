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
            return Ok(response);
        }

        [HttpPost]
        [Route("registrarMascotaPerdida")]
        [ProducesResponseType(typeof(RegistrarMascotaPerdidaCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> RegistrarMascotaPerdida(RegistrarMascotaPerdidaCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerMascota/{termino?}")]
        [ProducesResponseType(typeof(ObtenerMascotaQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerMascota(string? termino)
        {
            var response = await Mediator.Send(new ObtenerMascotaQuery()
            {
                Termino = termino
            });
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerMascotaPerdida/{termino?}")]
        [ProducesResponseType(typeof(ObtenerMascotaQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerMascotaPerdida(string? termino)
        {
            var response = await Mediator.Send(new ObtenerMascotaPerdidaQuery()
            {
                Termino = termino
            });
            return Ok(response);
        }
    }
}
