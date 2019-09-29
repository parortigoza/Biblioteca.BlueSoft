using Biblioteca.Models.Services;
using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models.Data
{
    public class DataCategoria: IServiceCategoria
    {
        private readonly BibliotecaDbContext _context;
        Utility.Util _utilRespuesta;
        string _mensaje;

        public DataCategoria(BibliotecaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene una lista de Categorias
        /// </summary>
        /// <returns>Lista de Categorias</returns>
        public RespuestaGenerica ObtenerCategorias()
        {
            _utilRespuesta = new Utility.Util();
            _mensaje = string.Empty;
            List<Categoria> CategoriaLista = new List<Categoria>();
            try
            {
                CategoriaLista = _context.Categoria.ToList();
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
            }

            return _utilRespuesta.ObtieneRespuesta(_mensaje, CategoriaLista);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objCategoria"></param>
        public RespuestaGenerica CrearCategoria(Categoria objCategoria)
        {
            _utilRespuesta = new Utility.Util();
            _mensaje = string.Empty;

            try
            {
                _context.Categoria.Add(objCategoria);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
            }
            return _utilRespuesta.ObtieneRespuesta(_mensaje, objCategoria);
        }

        /// <summary>
        /// Obtiene un Categoria por el índice de la tabla
        /// </summary>
        /// <param name="CategoriaId">Índice de la tabla para el registo del Categoria</param>
        public RespuestaGenerica ObtenerCategoria(int CategoriaId)
        {
            _utilRespuesta = new Utility.Util();
            _mensaje = string.Empty;
            Categoria objCategoria = new Categoria();
            try
            {
                objCategoria = _context.Categoria.Find(CategoriaId);
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
            }
            return _utilRespuesta.ObtieneRespuesta(_mensaje, objCategoria);
        }

        /// <summary>
        /// Actualiza la información de un Categoria
        /// </summary>
        /// <param name="objAutor"></param>
        public RespuestaGenerica ActualizarCategoria(Categoria objCategoria)
        {
            _utilRespuesta = new Utility.Util();
            _mensaje = string.Empty;

            try
            {
                _context.Entry(objCategoria).State = EntityState.Modified;
                _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
            }

            return _utilRespuesta.ObtieneRespuesta(_mensaje, objCategoria);
        }

        /// <summary>
        /// Elimina un Categoria
        /// </summary>
        /// <param name="CategoriaId"></param>
        public RespuestaGenerica EliminarCategoria(int CategoriaId)
        {
            _utilRespuesta = new Utility.Util();
            _mensaje = string.Empty;
            Categoria objCategoria = new Categoria();
            try
            {
                objCategoria = _context.Categoria.Find(CategoriaId);
                if (objCategoria != null)
                {
                    _context.Categoria.Remove(objCategoria);
                    _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
            }

            return _utilRespuesta.ObtieneRespuesta(_mensaje, objCategoria);
        }
    }
}
