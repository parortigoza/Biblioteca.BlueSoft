using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models.Services
{
    public interface IServiceAutor
    {
        RespuestaGenerica ObtenerAutores();
        RespuestaGenerica CrearAutor(Autor objAutor);
        RespuestaGenerica ObtenerAutor(int autorId);
        RespuestaGenerica ActualizarAutor(Autor objAutor);
        RespuestaGenerica EliminarAutor(int autorId);
    }
}
