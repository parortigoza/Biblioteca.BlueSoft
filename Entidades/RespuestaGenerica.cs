using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class RespuestaGenerica
    {
        public string Mensaje { get; set; }
        public bool TransaccionOk { get; set; }
        public object Entidad { get; set; }
    }
}
