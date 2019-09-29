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
    public class CategoriaController : ControllerBase
    {
        private RespuestaGenerica _respuesta;

        public CategoriaController(IServiceCategoria servicioCategoria, IServiceLog4Net serviceLog4Net)
        {
            _serviceLog4Net = serviceLog4Net;
            _serviceCategoria = servicioCategoria;
        }

        private IServiceLog4Net _serviceLog4Net { get; }
        private IServiceCategoria _serviceCategoria { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerCategorias")]
        public IActionResult Get()
        {
            _respuesta = _serviceCategoria.ObtenerCategorias();
            if (!_respuesta.TransaccionOk)
                _serviceLog4Net.EscribeLog4Net(_respuesta.Mensaje);
            return Ok(_respuesta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoriaId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerCategoria")]
        public IActionResult Get(int CategoriaId)
        {
            _respuesta = _serviceCategoria.ObtenerCategoria(CategoriaId);
            if (!_respuesta.TransaccionOk)
                _serviceLog4Net.EscribeLog4Net(_respuesta.Mensaje);
            return Ok(_respuesta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objCategoria"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CrearCategoria")]
        public IActionResult Post([FromBody] Categoria objCategoria)
        {
            _respuesta = _serviceCategoria.CrearCategoria(objCategoria);
            if (!_respuesta.TransaccionOk)
                _serviceLog4Net.EscribeLog4Net(_respuesta.Mensaje);
            return Ok(_respuesta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objCategoria"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ActualizarCategoria")]
        public IActionResult Put([FromBody] Categoria objCategoria)
        {
            _respuesta = _serviceCategoria.ActualizarCategoria(objCategoria);
            if (!_respuesta.TransaccionOk)
                _serviceLog4Net.EscribeLog4Net(_respuesta.Mensaje);
            return Ok(_respuesta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoriaId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("EliminarCategoria")]
        public IActionResult Delete(int CategoriaId)
        {
            _respuesta = _serviceCategoria.EliminarCategoria(CategoriaId);
            if (!_respuesta.TransaccionOk)
                _serviceLog4Net.EscribeLog4Net(_respuesta.Mensaje);
            return Ok(_respuesta);
        }
    }
}
