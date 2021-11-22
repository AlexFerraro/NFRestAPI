using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NFRestAPI.Domain.Interfaces;
using NFRestAPI.Infrastructure.Contexts;
using NFRestAPI.Infrastructure.EntityTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFRestAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public class NotaFiscalController : ControllerBase
    {
        private ILogger _logger;

        public NotaFiscalController(ILoggerFactory logger) => _logger = logger.CreateLogger<NotaFiscalController>();

        [HttpGet]
        [Route("{data}")]
        public async Task<IActionResult> GetNotaFiscalsByEmissionDate([FromServices] INotaFiscalRepository notaFiscalRepository, DateTime data)
        {
            try
            {
                var notasfiscais = await notaFiscalRepository.GetNotaFiscalByEmissionDateAsync(data);

                if (!notasfiscais.Any())
                    return NotFound();

                return Ok(notasfiscais);
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
