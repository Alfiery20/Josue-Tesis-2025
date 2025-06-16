using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesis2025.Application.Common.Dtos;

namespace Tesis2025.Application.Common.Exceptions
{
    public class DeleteFailureException : BaseException
    {
        public DeleteFailureException(MensajeUsuarioDTO message)
            : base(message)
        {
        }
    }
}
