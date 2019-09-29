using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models.Services
{
    public interface IServiceLibro
    {
        RespuestaGenerica ObtenerLibros();
        RespuestaGenerica CrearLibro(Libro objLibro);
        RespuestaGenerica ObtenerLibro(string Isbn);
        RespuestaGenerica ActualizarLibro(Libro objLibro);
        RespuestaGenerica EliminarLibro(string Isbn);
    }
}
