﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tesis2025.Application.Autenticacion.Command.ActualizarClave;
using Tesis2025.Application.Autenticacion.Command.EditarUsuario;
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
        public async Task<IActionResult> IniciarSesion(IniciarSesionCommand command)
        {
            var response = await Mediator.Send(command);
            if (response.Id == 0)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("registrar")]
        [ProducesResponseType(typeof(RegistrarCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Registrar(RegistrarCommand command)
        {
            var response = await Mediator.Send(command);
            if (response.Codigo != "OK")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("actualizarClave")]
        [ProducesResponseType(typeof(ActualizarClaveCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ActualizarClave(ActualizarClaveCommand command)
        {
            var response = await Mediator.Send(command);
            if (response.Codigo != "OK")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("editarUsuario")]
        [ProducesResponseType(typeof(EditarUsuarioCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarUsuario(EditarUsuarioCommand command)
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
