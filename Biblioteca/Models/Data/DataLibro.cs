using Biblioteca.Models.Services;
using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models.Data
{
    public class DataLibro: IServiceLibro
    {
        private readonly BibliotecaDbContext _context;
        Utility.Util _utilRespuesta;
        string _mensaje;

        public DataLibro(BibliotecaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene una lista de Libros
        /// </summary>
        /// <returns>Lista de Libros</returns>
        public RespuestaGenerica ObtenerLibros()
        {
            _utilRespuesta = new Utility.Util();
            _mensaje = string.Empty;
            List<Libro> LibroLista = new List<Libro>();
            try
            {
                LibroLista = _context.Libro.ToList();
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
            }

            return _utilRespuesta.ObtieneRespuesta(_mensaje, LibroLista);
        }

        /// <summary>
        /// Crea un registro de libro
        /// </summary>
        /// <param name="objLibro"></param>
        public RespuestaGenerica CrearLibro(Libro objLibro)
        {
            _utilRespuesta = new Utility.Util();
            _mensaje = string.Empty;

            try
            {
                _context.Libro.Add(objLibro);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
            }
            return _utilRespuesta.ObtieneRespuesta(_mensaje, objLibro);
        }

        /// <summary>
        /// Obtiene un Libro por el índice de la tabla
        /// </summary>
        /// <param name="LibroId">Índice de la tabla para el registo del Libro</param>
        public RespuestaGenerica ObtenerLibro(string Isbn)
        {
            _utilRespuesta = new Utility.Util();
            _mensaje = string.Empty;
            Libro objLibro = new Libro();
            try
            {
                objLibro = _context.Libro.Find(Isbn);
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
            }
            return _utilRespuesta.ObtieneRespuesta(_mensaje, objLibro);
        }

        /// <summary>
        /// Actualiza la información de un Libro
        /// </summary>
        /// <param name="objAutor"></param>
        public RespuestaGenerica ActualizarLibro(Libro objLibro)
        {
            _utilRespuesta = new Utility.Util();
            _mensaje = string.Empty;

            try
            {
                _context.Entry(objLibro).State = EntityState.Modified;
                _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
            }

            return _utilRespuesta.ObtieneRespuesta(_mensaje, objLibro);
        }

        /// <summary>
        /// Elimina un Libro
        /// </summary>
        /// <param name="LibroId"></param>
        public RespuestaGenerica EliminarLibro(string Isbn)
        {
            _utilRespuesta = new Utility.Util();
            _mensaje = string.Empty;
            Libro objLibro = new Libro();
            try
            {
                objLibro = _context.Libro.Find(Isbn);
                if (objLibro != null)
                {
                    _context.Libro.Remove(objLibro);
                    _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
            }

            return _utilRespuesta.ObtieneRespuesta(_mensaje, objLibro);
        }
    }
}
