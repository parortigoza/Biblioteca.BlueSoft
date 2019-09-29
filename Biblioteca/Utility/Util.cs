using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Utility
{
    public class Util
    {
        /// <summary>
        /// Arma una rspuesta genérica según resultado de una transacción
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar</param>
        /// <param name="entidad">Objeto para retornar como resultado</param>
        /// <returns>Objeto respuesta genérica</returns>
        public RespuestaGenerica ObtieneRespuesta(string mensaje, object entidad)
        {
            RespuestaGenerica respuesta = new RespuestaGenerica();
            if(!string.IsNullOrEmpty(mensaje))
            {
                respuesta.TransaccionOk = false;
                respuesta.Mensaje = mensaje;
            }
            else respuesta.TransaccionOk = true;
            respuesta.Entidad = entidad;
            return respuesta;
        }
    }
}
