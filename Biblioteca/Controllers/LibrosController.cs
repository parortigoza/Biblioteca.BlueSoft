using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models.Services;
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private RespuestaGenerica _respuesta;

        public LibrosController(IServiceLibro servicioLibro, IServiceLog4Net serviceLog4Net)
        {
            _serviceLog4Net = serviceLog4Net;
            _serviceLibro = servicioLibro;
        }

        private IServiceLog4Net _serviceLog4Net { get; }
        private IServiceLibro _serviceLibro { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerLibros")]
        public IActionResult Get()
        {
            _respuesta = _serviceLibro.ObtenerLibros();
            if (!_respuesta.TransaccionOk)
                _serviceLog4Net.EscribeLog4Net(_respuesta.Mensaje);
            return Ok(_respuesta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LibroId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerLibro")]
        public IActionResult Get(string Isbn)
        {
            _respuesta = _serviceLibro.ObtenerLibro(Isbn);
            if (!_respuesta.TransaccionOk)
                _serviceLog4Net.EscribeLog4Net(_respuesta.Mensaje);
            return Ok(_respuesta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objLibro"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CrearLibro")]
        public IActionResult Post([FromBody] Libro objLibro)
        {
            _respuesta = _serviceLibro.CrearLibro(objLibro);
            if (!_respuesta.TransaccionOk)
                _serviceLog4Net.EscribeLog4Net(_respuesta.Mensaje);
            return Ok(_respuesta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objLibro"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ActualizarLibro")]
        public IActionResult Put([FromBody] Libro objLibro)
        {
            _respuesta = _serviceLibro.ActualizarLibro(objLibro);
            if (!_respuesta.TransaccionOk)
                _serviceLog4Net.EscribeLog4Net(_respuesta.Mensaje);
            return Ok(_respuesta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LibroId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("EliminarLibro")]
        public IActionResult Delete(string Isbn)
        {
            _respuesta = _serviceLibro.EliminarLibro(Isbn);
            if (!_respuesta.TransaccionOk)
                _serviceLog4Net.EscribeLog4Net(_respuesta.Mensaje);
            return Ok(_respuesta);
        }
    }
}
