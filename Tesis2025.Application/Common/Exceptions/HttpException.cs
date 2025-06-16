﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesis2025.Application.Common.Dtos;

namespace Tesis2025.Application.Common.Exceptions
{
    public class HttpException : BaseException
    {
        public HttpException(int statusCode, MensajeUsuarioDTO message, Exception exception = null)
            : base(message, exception)
        {
            StatusCode = statusCode;
            Errores = new List<MensajeUsuarioDTO>();
        }

        public int StatusCode { get; }
        public IList<MensajeUsuarioDTO> Errores { get; set; }
    }
}
