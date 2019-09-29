using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models.Services
{
    public interface IServiceCategoria
    {
        RespuestaGenerica ObtenerCategorias();
        RespuestaGenerica CrearCategoria(Categoria objCategoria);
        RespuestaGenerica ObtenerCategoria(int CategoriaId);
        RespuestaGenerica ActualizarCategoria(Categoria objCategoria);
        RespuestaGenerica EliminarCategoria(int CategoriaId);
    }
}
