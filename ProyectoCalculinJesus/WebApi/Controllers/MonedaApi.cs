using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modelo;
using Repositorio;


namespace Api.Controllers
{
    [Route("Api/Monedas")]
    public class MonedaApi  : Controller

    {
        private ILogger<MonedaApi> _logger;
        private readonly IRepositorio _repositorio;

        public  MonedaApi(IRepositorio repositorio,ILogger<MonedaApi> logger)
        {
            _repositorio = repositorio;
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult ObtenerMonedas()
        {
            _logger.LogInformation("No se puede obtener la lista de monedas");
           
            return Ok(_repositorio.ObtenerMonedas());
        }
        [HttpGet("{id}")]
        public IActionResult ObtenerMoneda(int id)
        {
             _logger.LogInformation("No se puede obtener la lista de monedas");
            
            return Ok(_repositorio.BuscarMonedaPorId(id));
        }

        [HttpPost()]
        public IActionResult CrearMoneda([FromBody]Moneda moneda )
        {
            if (moneda == null)
            {
                 _logger.LogInformation("No se puede crear monedas");
            }
            _repositorio.CrearMoneda(moneda);
            return Ok(moneda);

            
        }
        [HttpPut()]
        public IActionResult ActualizarMoneda([FromBody]Moneda moneda)
        {
            if (moneda == null)
            {
               _logger.LogInformation("No se puede actualizar la moneda");
            }
            _repositorio.ActualizarMoneda(moneda);
           
            return Ok(moneda);
        }
        [HttpDelete("{id}")]
        public IActionResult BorrarMoneda(int id)
        {
            var moneda = _repositorio.BuscarMonedaPorId(id);
            if (moneda == null)
            {
                _logger.LogInformation("No se puede borrar la moneda");
            }
            _repositorio.BorrarMoneda(id);

            return Ok(id);
        }
    }

}
