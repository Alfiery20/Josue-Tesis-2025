using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesis2025.Application.Common.Dtos;

namespace Tesis2025.Application.Common.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(MensajeUsuarioDTO message)
            : base(message)
        {
        }
    }
}
