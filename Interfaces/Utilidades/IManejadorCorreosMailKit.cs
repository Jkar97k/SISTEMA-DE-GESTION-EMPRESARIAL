﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Interfaces.Utilidades
{
    public interface IManejadorCorreosMailKit
    {
        public Task Enviar(DatosEnvioCorreoDTO dto);
    }
}