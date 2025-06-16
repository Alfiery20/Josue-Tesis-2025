using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesis2025.Application.Common.Dtos;

namespace Tesis2025.Application.Common.Exceptions
{
    public abstract class BaseException : Exception
    {
        public BaseException(MensajeUsuarioDTO message, Exception exception = null)
            : base(message.Descripcion, exception)
        {
            MensajeUsuario = message;
        }

        public MensajeUsuarioDTO MensajeUsuario { get; }
    }
}
