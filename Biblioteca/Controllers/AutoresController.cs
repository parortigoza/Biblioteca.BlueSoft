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
    public class AutoresController : ControllerBase
    {
        private RespuestaGenerica _respuesta;
        
        public AutoresController(IServiceAutor servicioAutor, IServiceLog4Net serviceLog4Net)
        {
            _serviceLog4Net = serviceLog4Net;
            _serviceAutor = servicioAutor;
        }

        private IServiceLog4Net _serviceLog4Net { get; }
        private IServiceAutor _serviceAutor { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerAutores")]
        public IActionResult Get()
        {
            _respuesta = _serviceAutor.ObtenerAutores();
            if(!_respuesta.TransaccionOk)
                _serviceLog4Net.EscribeLog4Net(_respuesta.Mensaje);
            return Ok(_respuesta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="autorId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerAutor")]
        public IActionResult Get(int autorId)
        {
            _respuesta = _serviceAutor.ObtenerAutor(autorId);
            if (!_respuesta.TransaccionOk)
                _serviceLog4Net.EscribeLog4Net(_respuesta.Mensaje);
            return Ok(_respuesta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objAutor"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CrearAutor")]
        public IActionResult Post([FromBody] Autor objAutor)
        {
            _respuesta = _serviceAutor.CrearAutor(objAutor);
            if (!_respuesta.TransaccionOk)
                _serviceLog4Net.EscribeLog4Net(_respuesta.Mensaje);
            return Ok(_respuesta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objAutor"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ActualizarAutor")]
        public IActionResult Put([FromBody] Autor objAutor)
        {
            _respuesta = _serviceAutor.ActualizarAutor(objAutor);
            if (!_respuesta.TransaccionOk)
                _serviceLog4Net.EscribeLog4Net(_respuesta.Mensaje);
            return Ok(_respuesta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="autorId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("EliminarAutor")]
        public IActionResult Delete(int autorId)
        {
            _respuesta = _serviceAutor.EliminarAutor(autorId);
            if (!_respuesta.TransaccionOk)
                _serviceLog4Net.EscribeLog4Net(_respuesta.Mensaje);
            return Ok(_respuesta);
        }
    }
}
