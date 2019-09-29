using Biblioteca.Models.Services;
using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models.Data
{
    public class DataAutor: IServiceAutor
    {
        private readonly BibliotecaDbContext _context;
        Utility.Util _utilRespuesta;
        string _mensaje;

        public DataAutor(BibliotecaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene una lista de autores
        /// </summary>
        /// <returns>Lista de autores</returns>
        public RespuestaGenerica ObtenerAutores()
        {
            _utilRespuesta = new Utility.Util();
            _mensaje = string.Empty;
            List<Autor> autorLista = new List<Autor>();
            try
            {
                autorLista = _context.Autor.ToList();
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
            }
            
            return _utilRespuesta.ObtieneRespuesta(_mensaje, autorLista);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objAutor"></param>
        public RespuestaGenerica CrearAutor(Autor objAutor)
        {
            _utilRespuesta = new Utility.Util();
            _mensaje = string.Empty;

            try
            {
                _context.Autor.Add(objAutor);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
            }
            return _utilRespuesta.ObtieneRespuesta(_mensaje, objAutor);
        }

        /// <summary>
        /// Obtiene un autor por el índice de la tabla
        /// </summary>
        /// <param name="autorId">Índice de la tabla para el registo del autor</param>
        public RespuestaGenerica ObtenerAutor(int autorId)
        {
            _utilRespuesta = new Utility.Util();
            _mensaje = string.Empty;
            Autor objAutor = new Autor();
            try
            {
                objAutor = _context.Autor.Find(autorId);
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
            }
            return _utilRespuesta.ObtieneRespuesta(_mensaje, objAutor);
        }

        /// <summary>
        /// Actualiza lainformación de un autor
        /// </summary>
        /// <param name="objAutor"></param>
        public RespuestaGenerica ActualizarAutor(Autor objAutor)
        {
            _utilRespuesta = new Utility.Util();
            _mensaje = string.Empty;
            
            try
            {
                _context.Entry(objAutor).State = EntityState.Modified;
                _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
            }

            return _utilRespuesta.ObtieneRespuesta(_mensaje, objAutor);
        }

        /// <summary>
        /// Elimina un autor
        /// </summary>
        /// <param name="autorId"></param>
        public RespuestaGenerica EliminarAutor(int autorId)
        {
            _utilRespuesta = new Utility.Util();
            _mensaje = string.Empty;
            Autor objAutor = new Autor();
            try
            {
                objAutor = _context.Autor.Find(autorId);
                if (objAutor != null)
                {
                    _context.Autor.Remove(objAutor);
                    _context.SaveChangesAsync();
                }
                
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
            }

            return _utilRespuesta.ObtieneRespuesta(_mensaje, objAutor);
        }
    }
}
